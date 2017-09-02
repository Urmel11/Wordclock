using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.App.ClientProxies
{
	class EndpointConfigurationFactory : IEndpointConfigurationFactory
	{
		public static int Port { get; private set; }

		public static string Server { get; private set; }

		public static void Initialize(string server, int port) {
			Server = server;
			Port = port;
		}

		public Binding GetBinding() {
			return new BasicHttpBinding();
		}

		public EndpointAddress GetEndpointAddress() {
			return new EndpointAddress(string.Format("http://{0}:{1}/Wordclock", Server, Port));
		}
	}
}
