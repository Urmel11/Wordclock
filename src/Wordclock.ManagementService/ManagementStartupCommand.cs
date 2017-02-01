using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.SharedInterfaces;
using Wordclock.Core.Startup;

namespace Wordclock.ManagementService
{
	public class ManagementStartupCommand : IStartupCommand
	{
		private ServiceHost _host;

		public void Startup()
		{
			var machineName = Environment.MachineName;
			
			var baseAddress = new Uri(String.Format("http://{0}:6840/Wordclock", machineName));

			_host = new ServiceHost(typeof(WordclockService), baseAddress);

			var metaData = new ServiceMetadataBehavior();
			metaData.HttpGetEnabled = true;

			_host.Description.Behaviors.Add(metaData);

			_host.AddServiceEndpoint(typeof(IWordclockService), new BasicHttpBinding(), baseAddress);
			_host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

			_host.Open();
		}

		public void Shutdown()
		{
			_host.Close();
		}
				
	}
}
