using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	public class TimeSlotManager : ITimeSlotStoreObserver
	{
		private ITimeSlotObserver _timeSlotObserver;
		private ITimeSlotStore _timeSlotStore;
		private ITimeProvider _timeProvider;
		private Timer _timer;
		private PowerState? _state;

		public TimeSlotManager(ITimeSlotObserver timeSlotObserver,
								ITimeSlotStore timeSlotStore,
								ITimeProvider timeProvider)
		{
			_timeSlotObserver = timeSlotObserver;
			_timeProvider = timeProvider;
			_timer = new Timer(1000 * 60);
			_timeSlotStore = timeSlotStore;
			_timeSlotStore.RegisterForStoreValuesChanged(this);
						
			_timer.Elapsed += _timer_Elapsed;
			_timer.Start();
		}

		private bool IsTimeInTimeSlot()
		{
			DateTime currentTime = _timeProvider.GetDateTime();
			var timeSlotsOfDay = _timeSlotStore.GetTimeSlots().
									Where(x => x.DayOfWeek == currentTime.DayOfWeek && x.HasValue);
			
			return timeSlotsOfDay.Any(x => x.IsTimeInRange(currentTime.TimeOfDay));
		}

		private PowerState GetPowerStateOfTimeSlot()
		{
			if (IsTimeInTimeSlot())
			{
				return PowerState.On;
			}

			return PowerState.Off;
		}

		private void _timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			CheckTimeSlots();
		}

		private void CheckTimeSlots()
		{
			try
			{
				_timer.Enabled = false;
				var newPowerState = GetPowerStateOfTimeSlot();
				if (newPowerState != _state)
				{
					_timeSlotObserver.PowerStateChanged(newPowerState);
					_state = newPowerState;
				}
			}
			finally
			{
				_timer.Enabled = true;
			}
		}

		public void StoreValuesChanged()
		{
			CheckTimeSlots();
		}
	}
}
