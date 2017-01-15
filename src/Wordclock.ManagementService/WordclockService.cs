using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Core.PowerManagement;

namespace Wordclock.ManagementService
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class WordclockService : IWordclockService
	{
		public PowerState GetPowerState()
		{
			return Core.Wordclock.PowerManager.PowerState;
		}

		public void PowerOff()
		{
			Core.Wordclock.PowerManager.PowerOff();
		}

		public void PowerOn()
		{
			Core.Wordclock.PowerManager.PowerOn();
		}
	}
}
