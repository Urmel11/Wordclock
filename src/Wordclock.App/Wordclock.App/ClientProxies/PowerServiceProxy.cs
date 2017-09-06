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
			return new List<PowerTimeSlot>()
			{
				new PowerTimeSlot(){ DayOfWeek=DayOfWeek.Monday },
				new PowerTimeSlot(){ DayOfWeek=DayOfWeek.Tuesday },
				new PowerTimeSlot(){ DayOfWeek=DayOfWeek.Wednesday},
				new PowerTimeSlot(){ DayOfWeek=DayOfWeek.Thursday },
				new PowerTimeSlot(){ DayOfWeek=DayOfWeek.Friday },
				new PowerTimeSlot(){ DayOfWeek=DayOfWeek.Saturday },
				new PowerTimeSlot(){ DayOfWeek=DayOfWeek.Sunday }
			};
		}

		public PowerState GetPowerState()
		{
			return CreateInstance().GetPowerState();
		}

		public void SavePowerTimeSlots(IEnumerable<PowerTimeSlot> data)
		{
			throw new NotImplementedException();
		}

		public void SetPowerState(PowerState state)
		{
			CreateInstance().SetPowerState(state);
		}
	}
}
