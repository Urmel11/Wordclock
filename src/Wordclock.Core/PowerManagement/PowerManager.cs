using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	public class PowerManager
	{
		private IPowerObserver _observer;
		
		internal PowerManager(IPowerObserver observer)
		{
			_observer = observer;
			PowerState = PowerState.On;
		}

		public void PowerOn()
		{
			_observer.PowerOn();
			PowerState = PowerState.On;
		}

		public void PowerOff()
		{
			_observer.PowerOff();
			PowerState = PowerState.Off;
		}

		public PowerState PowerState { get; private set; }
	}
}
