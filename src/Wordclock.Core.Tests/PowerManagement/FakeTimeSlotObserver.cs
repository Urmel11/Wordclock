using Wordclock.Core.PowerManagement;
using Wordclock.Shared.Services;

namespace Wordclock.Core.Tests.PowerManagement
{
	class FakeTimeSlotObserver : ITimeSlotObserver
	{
		public FakeTimeSlotObserver()
		{
			CurrentPowerState = null;
			Calls = 0;
		}

		public PowerState? CurrentPowerState { get; set; }

		public int Calls { get; private set; }

		public void PowerStateChanged(PowerState newState)
		{
			Calls++;
			CurrentPowerState = newState;
		}
	}
}
