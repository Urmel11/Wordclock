using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Wordclock.Core.PowerManagement
{
	public class PowerManager
	{
		private IPowerObserver _observer;
		private Timer _timer;
		private PowerState _currentState;

		internal PowerManager(IPowerObserver observer, IPowerStore store)
		{
			_observer = observer;
			Store = store;
			_currentState = PowerState.PowerOn;
			InitTimer();
		}

		private void InitTimer()
		{
			_timer = new Timer();
			_timer.Interval = 5 * 1000;
			_timer.Elapsed += TimerElapsed;
			_timer.Enabled = true;
			_timer.Start();
		}

		private void TimerElapsed(object sender, ElapsedEventArgs e)
		{
			_timer.Enabled = false;

			var newState = Store.GetPowerState(DateTime.Now);

			if(newState != _currentState)
			{
				if(newState == PowerState.PowerOn)
				{
					_observer.PowerOn();
				}
				else
				{
					_observer.PowerOff();
				}

				_currentState = newState;
			}

			_timer.Enabled = true;
		}

		public IPowerStore Store { get; private set; }
	}
}
