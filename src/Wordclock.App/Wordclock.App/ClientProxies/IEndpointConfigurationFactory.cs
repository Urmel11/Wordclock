using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.App.ClientProxies
{
	interface IEndpointConfigurationFactory
	{
		Binding GetBinding();

		EndpointAddress GetEndpointAddress();
	}
}
