using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Wordclock.Core.PowerManagement;
using Wordclock.Core.Tests.Utils;

namespace Wordclock.Core.Tests.PowerManagement
{
	class TimeSlotManagerTests
	{
		private TimeSlotManager _timeSlotManager;
		private FakeTimeSlotObserver _timeSlotObserver;
		private FakeTimeProvider _timeProvider;
		private List<PowerTimeSlot> _timeSlots;
		private FakeTimer _timer;

		[SetUp]
		public void SetUp()
		{
			_timeSlotObserver = new FakeTimeSlotObserver();
			_timeProvider = new FakeTimeProvider();
			_timer = new FakeTimer();

			var timeSlotStore = new Mock<ITimeSlotStore>();
			_timeSlots = new List<PowerTimeSlot>();
			timeSlotStore.Setup(x => x.GetTimeSlots()).Returns(_timeSlots);

			_timeSlotManager = new TimeSlotManager(_timeSlotObserver, _timer, _timeProvider, timeSlotStore.Object);
		}
				
		[TestCase("2018-3-19T14:00:01", PowerState.On)]
		[TestCase("2018-3-19T14:10:59", PowerState.On)]
		[TestCase("2018-3-19T14:11:00", PowerState.Off)]
		[TestCase("2018-3-19T14:00:00", PowerState.Off)]
		public void Notifies_PowerState_In_Respect_Of_TimeSlot(DateTime currentDate, PowerState state)
		{
			_timeProvider.Time = currentDate;

			_timeSlots.Add(new PowerTimeSlot()
			{
				DayOfWeek = DayOfWeek.Monday,
				StarTime = new TimeSpan(14, 0, 1),
				EndTime = new TimeSpan(14, 10, 59)
			});
			
			_timeSlotManager.Start();

			_timeSlotObserver.CurrentPowerState.Should().Be(state);
		}

		[Test]
		public void Does_Not_Notify_If_PowerState_Is_Not_Changed()
		{
			_timeSlots.Add(new PowerTimeSlot()
			{
				DayOfWeek = DayOfWeek.Monday,
				StarTime = new TimeSpan(14, 0, 0),
				EndTime = new TimeSpan(15, 0, 0)
			});

			_timeProvider.Time = new DateTime(2018, 3, 19, 13, 0, 0);

			//Check the first time, if the given date matches the TimeSlot.
			_timeSlotManager.Start();

			//Check the second time, if the given date matches the TimeSlot.
			//The observer should not be notified, because the state did not changed
			_timer.Start();

			_timeSlotObserver.Calls.Should().Be(1, "because PowerState is still off.");
		}

		[Test]
		public void Notifies_If_PowerState_Changed()
		{
			_timeSlots.Add(new PowerTimeSlot()
			{
				DayOfWeek = DayOfWeek.Monday,
				StarTime = new TimeSpan(14, 0, 0),
				EndTime = new TimeSpan(15, 0, 0)
			});

			_timeProvider.Time = new DateTime(2018, 3, 19, 13, 0, 0);

			_timeSlotManager.Start();

			_timeProvider.Time = new DateTime(2018, 3, 19, 14, 10, 0);
			_timer.Start();

			_timeSlotObserver.Calls.Should().Be(2);
		}

		[Test]
		public void Checks_TimeSlots_If_TimeSlotStore_Was_Updated()
		{
			_timeSlots.Add(new PowerTimeSlot()
			{
				DayOfWeek = DayOfWeek.Monday,
				StarTime = new TimeSpan(14, 0, 0),
				EndTime = new TimeSpan(15, 0, 0)
			});

			_timeProvider.Time = new DateTime(2018, 3, 19, 14, 10, 0);

			_timeSlotManager.Start();
			_timeSlotObserver.CurrentPowerState.Should().Be(PowerState.On);

			_timeSlots.First().EndTime = new TimeSpan(14, 5, 0);
			_timeSlotManager.SaveTimeSlots(_timeSlots);

			_timeSlotObserver.CurrentPowerState.Should().Be(PowerState.Off);
			_timeSlotObserver.Calls.Should().Be(2);
		}

		[TestCase(PowerState.On)]
		[TestCase(PowerState.Off)]
		public void Does_Not_Change_Lights_If_Default_Configuration_Is_Set(PowerState state)
		{
			_timeProvider.Time = DateTime.Now;

			_timeSlotObserver.CurrentPowerState = state;

			_timeSlots.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Monday });
			_timeSlots.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Tuesday });
			_timeSlots.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Wednesday });
			_timeSlots.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Thursday });
			_timeSlots.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Friday });
			_timeSlots.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Saturday });
			_timeSlots.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Sunday });

			_timeSlotManager.Start();

			_timeSlotObserver.CurrentPowerState.Should().Be(state);
		}
	}
}
