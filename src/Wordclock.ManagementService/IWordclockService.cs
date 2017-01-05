using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.ManagementService
{
	[ServiceContract]
	public interface IWordclockService
	{
		[OperationContract]
		string TestConnect();
	}
}
