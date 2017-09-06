using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Shared.Services
{
	[ServiceContract]
	public interface IPowerService
	{
		[OperationContract]
		List<PowerTimeSlot> GetPowerTimeSlots();

		[OperationContract]
		PowerState GetPowerState();

		[OperationContract]
		void SetPowerState(PowerState state);

		[OperationContract]
		void SavePowerTimeSlots(IEnumerable<PowerTimeSlot> data);
	}
}
