using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Counters
{
	internal class Model
	{
		private readonly string _connectionString =
			ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		private readonly string _tableName = "counters";

		private readonly SimpleRwLock _locker = new SimpleRwLock();

		private Dictionary<string, ConstantRateCounter> _counters =
			new Dictionary<string, ConstantRateCounter>();

		private bool _isSynchronized = false;

		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="KeyNotFoundException"></exception>
		public ConstantRateCounter this[string name]
		{
			get
			{
				_locker.EnterReadLock();
				try
				{
					return _counters[name];
				}
				finally
				{
					_locker.ExitReadLock();
				}
			}
			set
			{
				if (name == null)
					throw new ArgumentNullException(nameof(name));
				_locker.EnterWriteLock();
				try
				{
					if (value == null)
						if (!_counters.ContainsKey(name))
							throw new KeyNotFoundException(nameof(name));
						else
							_counters.Remove(name);
					else
						_counters[name] = value;
				}
				finally
				{
					_isSynchronized = false;
					_locker.ExitWriteLock();
				}
			}
		}

		public IEnumerable<KeyValuePair<string, ConstantRateCounter>> EnumerateContent()
		{
			_locker.EnterReadLock();
			try
			{
				return _counters.ToArray();
			}
			finally
			{
				_locker.ExitReadLock();
			}
		}

		public async Task SaveAsync()
		{
			_locker.EnterReadLock();
			try
			{
				if (_isSynchronized) return;
				var data = EnumerateContent();
				using (var connection = new SqlConnection(_connectionString))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					var transaction = connection.BeginTransaction();
					try
					{
						await ClearDatabase(connection, transaction).ConfigureAwait(false);
						await PopulateDatabase(connection, transaction, data).ConfigureAwait(false);
						transaction.Commit();
						_isSynchronized = true;
					}
					catch
					{
						transaction.Rollback();
						throw;
					}
				}
			}
			finally
			{
				_locker.ExitReadLock();
			}
		}

		public async Task LoadAsync()
		{
			_locker.EnterWriteLock();
			try
			{
				if (_isSynchronized) return;
				using (var connection = new SqlConnection(_connectionString))
				{
					await connection.OpenAsync();
					var response = await ReadDatabase(connection);
					lock (_locker)
					{
						_counters = response;
						_isSynchronized = true;
					}
				}
			}
			finally
			{
				_locker.ExitWriteLock();
			}
	}

		private async Task<Dictionary<string, ConstantRateCounter>> ReadDatabase(SqlConnection connection)
		{
			var command = connection.CreateCommand();
			command.CommandText = $"SELECT * FROM {_tableName}";
			var reader = await command.ExecuteReaderAsync();
			var result = new Dictionary<string, ConstantRateCounter>();
			while (await reader.ReadAsync())
			{
				var name = reader.GetString(1);
				var bytes = (byte[])reader.GetValue(2);
				var counter = ConstantRateCounterSerializer.Deserialize(bytes);
				result.Add(name, counter);
			}
			return result;
		}

		private async Task PopulateDatabase(SqlConnection connection, SqlTransaction transaction,
			IEnumerable<KeyValuePair<string, ConstantRateCounter>> data)
		{
			var commandText = $"INSERT INTO {_tableName} (Name, Counter) VALUES (@name, @counter)";
			foreach (var pair in data)
			{
				var command = connection.CreateCommand();
				command.Transaction = transaction;
				command.CommandText = commandText;
				command.Parameters.AddWithValue("@name", pair.Key);
				command.Parameters.AddWithValue("@counter",
					ConstantRateCounterSerializer.Serialize(pair.Value));
				await command.ExecuteNonQueryAsync();
			}
		}

		private async Task ClearDatabase(SqlConnection connection, SqlTransaction transaction)
		{
			var command = connection.CreateCommand();
			command.Transaction = transaction;
			command.CommandText = $"DELETE FROM {_tableName}";
			await command.ExecuteNonQueryAsync();
		}
	}
}
