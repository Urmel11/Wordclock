using Wordclock.Core.Utils;

namespace Wordclock.Core.Tests.Utils
{
	class FakeTimer : ITimer
	{
		private ITimerObserver _observer;

		public void DisableTimer()
		{
			
		}

		public void EnableTimer()
		{
			
		}

		public void RegisterForTimerElapsed(ITimerObserver observer)
		{
			_observer = observer;
		}

		public void Start()
		{
			_observer.TimerElapsed();
		}
	}
}
