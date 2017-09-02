using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.App.ClientProxies
{
	class ConnectionServiceProxy : Proxy<IConnectionService>, IConnectionService
	{
		public ConnectionServiceProxy(IEndpointConfigurationFactory configurationFactory) : base(configurationFactory)	{ }

		public bool IsConnectionEstablished() {
			return CreateInstance().IsConnectionEstablished();
		}
	}
}
