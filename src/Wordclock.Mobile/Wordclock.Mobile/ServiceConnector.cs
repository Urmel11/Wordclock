using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Mobile
{
	class ServiceConnector
	{
		public static T CreateInstance<T>()
		{
			var channel = new ChannelFactory<T>(new BasicHttpBinding(), Endpoint);

			return channel.CreateChannel(Endpoint);
		}

		public static void Initialize(string server, int port)
		{
			Server = server;
			Port = port;
		}

		public static string Server { get; private set; }

		public static int Port { get; private set; }

		public static EndpointAddress Endpoint
		{
			get
			{
				return new EndpointAddress(string.Format("http://{0}:{1}/Wordclock", Server, Port));
			}
		}
	}
}
