using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Wordclock.Core.Startup;

namespace Wordclock.Core.WordclockManagement
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

			var binding = new BasicHttpBinding();
			//Increase message size to receive data from the update service
			binding.MaxReceivedMessageSize = 5 * 1024 * 1024;
			
			_host.AddServiceEndpoint(typeof(IWordclockService), binding, baseAddress);
			_host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

			_host.Open();
		}

		public void Shutdown()
		{
			_host.Close();
		}
		
	}
}
