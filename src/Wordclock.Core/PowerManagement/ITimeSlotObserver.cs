using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	public interface ITimeSlotObserver
	{
		void PowerStateChanged(PowerState newState);
	}
}
