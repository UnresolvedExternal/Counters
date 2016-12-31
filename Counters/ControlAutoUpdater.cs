using System;
using System.Windows.Forms;

namespace Counters
{
	internal class ControlAutoUpdater: IDisposable
	{
		private readonly Action _action;
		private readonly Func<bool> _isOutdated;
		private readonly Timer _timer;
		private bool _disposed;

		public ControlAutoUpdater(Action action, Func<bool> isOutdated, int interval)
		{
			if (action == null) throw new ArgumentNullException(nameof(action));
			if (isOutdated == null) throw new ArgumentNullException(nameof(isOutdated));
			if (interval <= 0) throw new ArgumentOutOfRangeException(nameof(interval));

			_action = action;
			_isOutdated = isOutdated;
			_timer = new Timer {Interval = interval};
			_timer.Tick += (s, a) => RunOneIteration();
			_timer.Enabled = true;
		}

		private void RunOneIteration()
		{
			if (_isOutdated())
				_action();
		}

		public static ControlAutoUpdater Create(Action action,
			Func<bool> isOutdated, int interval)
		{
			return new ControlAutoUpdater(action, isOutdated, interval);
		}

		public void Dispose()
		{
			if (_disposed) return;
			_timer.Dispose();
			_disposed = true;
		}
	}
}
