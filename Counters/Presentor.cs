using System;
using System.Collections.Generic;

namespace Counters
{
	internal class Presentor
	{
		private readonly IView _view;
		private readonly Model _model;

		public Presentor(IView view, Model model)
		{
			_view = view;
			_model = model;
			_view.AllowEdit = true;
			_view.Counters = _model.EnumerateContent();
			_view.AddCounterRequested += _view_AddCounterRequested;
			_view.EditCounterRequested += _view_EditCounterRequested;
			_view.LoadRequested += _view_LoadRequested;
			_view.SaveRequested += _view_SaveRequested;
			_view.RemoveCounterRequested += _view_RemoveCounterRequested;
		}

		private void _view_RemoveCounterRequested()
		{
			var name = _view.RemoveCounter();
			if (name == null)
				return;
			try
			{
				_model[name] = null;
				_view.Counters = _model.EnumerateContent();
			}
			catch (KeyNotFoundException)
			{
				_view.Log("Счётчика с таким именем не существует!");
			}
		}

		private async void _view_SaveRequested()
		{
			_view.AllowEdit = false;
			try
			{
				await _model.SaveAsync();
			}
			catch (Exception e)
			{
				_view.Log($"Ошибка при сохранении: {e.Message}");
			}
			finally
			{
				_view.AllowEdit = true;
			}
		}

		private async void _view_LoadRequested()
		{
			_view.AllowEdit = false;
			try
			{
				await _model.LoadAsync();
				_view.Counters = _model.EnumerateContent();
			}
			catch (Exception e)
			{
				_view.Log($"Ошибка при загрузке: {e.Message}");
			}
			finally
			{
				_view.AllowEdit = true;
			}
		}

		private void _view_EditCounterRequested()
		{
			string oldName;
			var pair = _view.EditCounter(out oldName);
			if (HasNull(pair))
				return;
			try
			{
				var oldValue = _model[oldName];
			}
			catch (KeyNotFoundException)
			{
				_view.Log($"Счётчика с названием {oldName} не существует!");
				return;
			}

			try
			{
				if (pair.Key == oldName)
					throw new KeyNotFoundException("It's ok - no conflict!");
				var value = _model[pair.Key];
				_view.Log("Счётчик с таким названием уже существует!");
			}
			catch (KeyNotFoundException)
			{
				_model[oldName] = null;
				_model[pair.Key] = pair.Value;
				_view.Counters = _model.EnumerateContent();
			}
		}

		private static bool HasNull(KeyValuePair<string, ConstantRateCounter> pair)
		{
			return pair.Key == null || pair.Value == null;
		}

		private void _view_AddCounterRequested()
		{
			var pair = _view.AddCounter();
			if (HasNull(pair))
				return;
			try
			{
				var value = _model[pair.Key];
				_view.Log("Счётчик с таким именем уже существует!");
			}
			catch (KeyNotFoundException)
			{
				_model[pair.Key] = pair.Value;
				_view.Counters = _model.EnumerateContent();
			}
		}
	}
}
