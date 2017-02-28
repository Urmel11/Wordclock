using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Wordclock.Mobile
{
	class ServiceConnector
	{
		public static T CreateInstance<T>()
		{
			var channel = new ChannelFactory<T>(new BasicHttpBinding(), Endpoint);
			
			return channel.CreateChannel(Endpoint);
		}

		public static string Server { get; set; }
		
		public static int Port { get; set; }
		
		public static EndpointAddress Endpoint
		{
			get
			{
				return new EndpointAddress(string.Format("http://{0}:{1}/Wordclock", Server, Port));
			}
		}
	}
}
