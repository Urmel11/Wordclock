using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Wordclock.Core.PowerManagement;

namespace Wordclock.Core.Tests.PowerManagement
{
	class TimeSlotStoreDecoratorTests
	{
		public class GetTimeSlotsMethod : TimeSlotStoreDecoratorTests
		{
			[Test]
			public void Returns_Existing_Time_Slots()
			{
				var timeSlots = new List<PowerTimeSlot>();
				timeSlots.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Friday });

				var store = InitTestStore(timeSlots);

				var result = store.GetTimeSlots();

				result.Should().BeEquivalentTo(timeSlots);
			}

			[Test]
			public void Returns_Default_TimeSlots_If_There_Are_No_Entries_In_Store()
			{
				var store = InitTestStore(null);

				var result = store.GetTimeSlots();

				result.Should().HaveCount(7);
			}

			private TimeSlotStoreDecorator InitTestStore(List<PowerTimeSlot> entiresToReturn)
			{
				var timeSlotStore = new Mock<ITimeSlotStore>();
				timeSlotStore.Setup(x => x.GetTimeSlots()).Returns(entiresToReturn);

				return new TimeSlotStoreDecorator(timeSlotStore.Object);
			}
		}
	}
}
