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

		public List<PowerTimeSlot> GetPowerTimeSlots()
		{
			return CreateInstance().GetPowerTimeSlots();
		}

		public PowerState GetPowerState()
		{
			return CreateInstance().GetPowerState();
		}

		public void SavePowerTimeSlots(IEnumerable<PowerTimeSlot> data)
		{
			CreateInstance().SavePowerTimeSlots(data);
		}

		public void SetPowerState(PowerState state)
		{
			CreateInstance().SetPowerState(state);
		}
	}
}
