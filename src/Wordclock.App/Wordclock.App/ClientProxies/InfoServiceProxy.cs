using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.App.ClientProxies
{
	class InfoServiceProxy : Proxy<IInfoService>, IInfoService
	{
		public InfoServiceProxy(IEndpointConfigurationFactory endpointFactory) : base(endpointFactory) { }

		public InfoData GetInformationData() {
			return CreateInstance().GetInformationData();
		}
	}
}
