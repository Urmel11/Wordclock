using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.App.ClientProxy
{
	class ConnectionServiceProxy : Proxy<IConnectionService>, IConnectionService
	{
		public ConnectionServiceProxy(IEndpointConfigurationFactory configurationFactory) : base(configurationFactory)	{ }

		public bool IsConnectionEstablished() {
			return CreateInstance().IsConnectionEstablished();
		}
	}
}
