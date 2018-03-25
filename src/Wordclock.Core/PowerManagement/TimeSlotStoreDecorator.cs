using System;
using System.Collections.Generic;
using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	public class TimeSlotStoreDecorator : ITimeSlotStore
	{
		private ITimeSlotStore _store;

		public TimeSlotStoreDecorator(ITimeSlotStore store)
		{
			_store = store;
		}

		public List<PowerTimeSlot> GetTimeSlots()
		{
			List<PowerTimeSlot> result;

			result = _store.GetTimeSlots();

			if(result == null)
			{
				result = GetDefaultTimeSlots();
			}

			return result;
		}

		public void SaveTimeSlots(IEnumerable<PowerTimeSlot> timeSlotsToSave)
		{
			_store.SaveTimeSlots(timeSlotsToSave);
		}

		private List<PowerTimeSlot> GetDefaultTimeSlots()
		{
			var result = new List<PowerTimeSlot>();

			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Monday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Tuesday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Wednesday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Thursday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Friday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Saturday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Sunday });

			return result;
		}
	}
}
