using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	public interface ITimeSlotStore
	{
		void SaveTimeSlots(IEnumerable<PowerTimeSlot> timeSlotsToSave);

		List<PowerTimeSlot> GetTimeSlots();

		void RegisterForStoreValuesChanged(ITimeSlotStoreObserver observer);
	}
}
