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
		public PowerState GetPowerState()
		{
			return Wordclock.RenderEngine.GetPowerState();
		}

		public List<PowerTimeSlot> GetPowerTimeSlots()
		{
			return Wordclock.TimeSlotManager.GetTimeSlots();
		}
		
		public void SavePowerTimeSlots(IEnumerable<PowerTimeSlot> data)
		{
			Wordclock.TimeSlotManager.SaveTimeSlots(data);
		}

		public void SetPowerState(PowerState state)
		{
			Wordclock.RenderEngine.SetPowerState(state);
		}
	}
}
