using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Core.PowerManagement;

namespace Wordclock.ManagementService
{
	[ServiceContract]
	public interface IWordclockService
	{
		[OperationContract]
		void PowerOn();

		[OperationContract]
		void PowerOff();

		[OperationContract]
		PowerState GetPowerState();
	}
}
