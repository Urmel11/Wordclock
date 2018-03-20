using System.Collections.Generic;
using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	public interface ITimeSlotStore
	{
		void SaveTimeSlots(IEnumerable<PowerTimeSlot> timeSlotsToSave);

		List<PowerTimeSlot> GetTimeSlots();
	}
}
