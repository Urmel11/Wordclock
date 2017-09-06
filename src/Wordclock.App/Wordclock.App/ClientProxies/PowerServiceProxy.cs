using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.App.ClientProxies
{
	class PowerServiceProxy : Proxy<IPowerService>, IPowerService
	{
		public PowerServiceProxy(IEndpointConfigurationFactory endpointFactory) : base(endpointFactory) { }

		public List<PowerEntry> GetPowerData()
		{
			return new List<PowerEntry>()
			{
				new PowerEntry(){ DayOfWeek=DayOfWeek.Monday },
				new PowerEntry(){ DayOfWeek=DayOfWeek.Tuesday },
				new PowerEntry(){ DayOfWeek=DayOfWeek.Wednesday},
				new PowerEntry(){ DayOfWeek=DayOfWeek.Thursday },
				new PowerEntry(){ DayOfWeek=DayOfWeek.Friday },
				new PowerEntry(){ DayOfWeek=DayOfWeek.Saturday },
				new PowerEntry(){ DayOfWeek=DayOfWeek.Sunday }
			};
		}

		public PowerState GetPowerState()
		{
			return CreateInstance().GetPowerState();
		}

		public void SavePowerData(IEnumerable<PowerEntry> data)
		{
			throw new NotImplementedException();
		}

		public void SetPowerState(PowerState state)
		{
			CreateInstance().SetPowerState(state);
		}
	}
}
