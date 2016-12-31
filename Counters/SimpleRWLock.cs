using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Counters
{
	class SimpleRwLock
	{
		private int _readers;
		private readonly object _locker = new object();
		private readonly ManualResetEventSlim _writeLocker = new ManualResetEventSlim(true);

		public void EnterReadLock()
		{
			lock (_locker)
			{
				while (!_writeLocker.IsSet)
				{
					Monitor.Wait(_locker);
				}
				Interlocked.Increment(ref _readers);
			}
		}

		public void ExitReadLock()
		{
			lock (_locker)
			{
				if (_readers == 0)
					throw new SynchronizationLockException("Exit read lock when read lock isn't held.");
				Interlocked.Decrement(ref _readers);
				if (_readers == 0)
					Monitor.Pulse(_locker);
			}
		}

		public void EnterWriteLock()
		{
			lock (_locker)
			{
				while (_readers > 0 || !_writeLocker.IsSet)
					Monitor.Wait(_locker);
				_writeLocker.Reset();
			}
		}

		public void ExitWriteLock()
		{
			lock (_locker)
			{
				if (_writeLocker.IsSet)
					throw new SynchronizationLockException("Exit write lock when write lock isn't held.");
				_writeLocker.Set();
				Monitor.PulseAll(_locker);
			}
		}
	}
}
