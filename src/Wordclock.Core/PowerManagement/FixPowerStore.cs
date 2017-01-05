using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Core.PowerManagement
{
	public class FixPowerStore : IPowerStore
	{		
		public PowerState GetPowerState(DateTime date)
		{
			return PowerState.PowerOff;	
		}
	}
}
