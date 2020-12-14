using System;
using System.Timers;

namespace Wordclock.Core.Utils
{
	public class WordclockTimer : ITimer, IDisposable
	{
		private Timer _timer;
		private ITimerObserver? _timerObserver;

		public WordclockTimer(double interval)
		{
			_timer = new Timer();
			_timer.Interval = interval;
			_timer.Elapsed += Timer_Elapsed;
		}

		public void Start()
		{
			_timerObserver?.TimerElapsed();
			_timer.Start();
		}

		public void DisableTimer()
		{
			_timer.Enabled = false;
		}

		public void EnableTimer()
		{
			_timer.Enabled = true;
		}

		public void RegisterForTimerElapsed(ITimerObserver observer)
		{
			_timerObserver = observer;
		}

		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			DisableTimer();

			_timerObserver?.TimerElapsed();

			EnableTimer();
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					_timer.Stop();
					_timer.Elapsed -= Timer_Elapsed;
					_timer.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~WordclockTimer() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		#endregion

	}
}
