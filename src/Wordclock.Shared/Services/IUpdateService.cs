using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Shared.Services
{
	[ServiceContract]
	public interface IUpdateService
	{
		[OperationContract]
		void TransferContent(IEnumerable<FileContent> content, bool clearDestinationDirectory);

		[OperationContract]
		bool IsUpdateRequired(string newVersion);
	}
}
