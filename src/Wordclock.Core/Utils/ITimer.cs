namespace Wordclock.Core.Utils
{
	public interface ITimer
	{
		void RegisterForTimerElapsed(ITimerObserver observer);

		void EnableTimer();

		void DisableTimer();

		void Start();
	}
}
