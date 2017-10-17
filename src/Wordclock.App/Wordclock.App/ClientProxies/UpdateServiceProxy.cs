using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.App.ClientProxies
{
	class UpdateServiceProxy : Proxy<IUpdateService>, IUpdateService
	{
		public UpdateServiceProxy(IEndpointConfigurationFactory configurationFactory) : base(configurationFactory)	{ }

		public bool IsUpdateRequired(string newVersion)
		{
			return CreateInstance().IsUpdateRequired(newVersion);
		}

		public void TransferContent(IEnumerable<FileContent> content, bool clearDestinationDirectory)
		{
			CreateInstance().TransferContent(content, clearDestinationDirectory);
		}
	}
}
