using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.Core.WordclockManagement
{
	public partial class WordclockService : IPowerService
	{
		public List<PowerEntry> GetPowerData()
		{
			throw new NotImplementedException();
		}

		public PowerState GetPowerState()
		{
			return Wordclock.PowerManager.PowerState;
		}

		public void SavePowerData(IEnumerable<PowerEntry> data)
		{
			throw new NotImplementedException();
		}

		public void SetPowerState(PowerState state)
		{
			if(state == PowerState.On)
			{
				Wordclock.PowerManager.PowerOn();
			}
			else
			{
				Wordclock.PowerManager.PowerOff();
			}
		}
	}
}
