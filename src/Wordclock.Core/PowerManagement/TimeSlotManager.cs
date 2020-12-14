using System.Collections.Generic;
using System.Linq;
using Wordclock.Core.Utils;

namespace Wordclock.Core.PowerManagement
{
	public class TimeSlotManager : ITimerObserver, ITimeSlotStore
	{
		private ITimeSlotObserver _timeSlotObserver;
		private ITimer _timer;
		private ITimeProvider _timeProvider;
		private ITimeSlotStore _timeSlotStore;
		private PowerState? _currentPowerState;

		public TimeSlotManager(ITimeSlotObserver timeSlotObserver, 
								ITimer timer,
								ITimeProvider timeProvider,
								ITimeSlotStore timeSlotStore)
		{
			_timeSlotObserver = timeSlotObserver;
			_timer = timer;
			_timeProvider = timeProvider;
			_timeSlotStore = timeSlotStore;
			_currentPowerState = null;

			_timer.RegisterForTimerElapsed(this);
		}

		public void Start()
		{
			_timer.Start();
		}

		private void CheckTimeSlots()
		{
			var timeSlotPowerState = GetPowerStateInRespectOfTimeSlot();
			if (timeSlotPowerState is null)
				return;

			if(timeSlotPowerState != _currentPowerState)
			{
				_timeSlotObserver.PowerStateChanged(timeSlotPowerState.Value);
				_currentPowerState = timeSlotPowerState;
			}
		}

		private PowerState? GetPowerStateInRespectOfTimeSlot()
		{
			var timeSlots = _timeSlotStore.GetTimeSlots();
			if (timeSlots is null)
				return null;

			if(!timeSlots.Any(x => x.HasValue))
			{
				return _currentPowerState;
			}

			var currentTime = _timeProvider.GetDateTime();

			var isCurrentTimeInTimeSlot = timeSlots.Any(x => x.IsTimeInTimeSlot(currentTime));

			if (isCurrentTimeInTimeSlot)
			{
				return PowerState.On;
			}

			return PowerState.Off;
		}

		public void TimerElapsed()
		{
			CheckTimeSlots();
		}

		public void SaveTimeSlots(IEnumerable<PowerTimeSlot> timeSlotsToSave)
		{
			_timer.DisableTimer();

			_timeSlotStore.SaveTimeSlots(timeSlotsToSave);
			CheckTimeSlots();

			_timer.EnableTimer();
		}

		public List<PowerTimeSlot>? GetTimeSlots()
		{
			return _timeSlotStore.GetTimeSlots();
		}
	}
}
