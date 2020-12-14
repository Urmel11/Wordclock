using System.Collections.Generic;

namespace Wordclock.Core.PowerManagement
{
	public interface ITimeSlotStore
	{
		void SaveTimeSlots(IEnumerable<PowerTimeSlot> timeSlotsToSave);

		List<PowerTimeSlot>? GetTimeSlots();
	}
}
