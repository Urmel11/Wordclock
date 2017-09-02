using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.App.ClientProxies
{
	class Proxy<T> : IDisposable
	{
		ChannelFactory<T> _channel;
		
		public Proxy(IEndpointConfigurationFactory configurationFactory) {
			EndpointConfigurationFactory = configurationFactory;
		}

		protected T CreateInstance() {
			EnsureChannelExist();

			return _channel.CreateChannel(EndpointConfigurationFactory.GetEndpointAddress());
		}

		private void EnsureChannelExist() {
			if(_channel == null) {
				_channel = new ChannelFactory<T>(EndpointConfigurationFactory.GetBinding(), EndpointConfigurationFactory.GetEndpointAddress());
			}
		}
		
		public IEndpointConfigurationFactory EndpointConfigurationFactory { get; private set; }

	#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					_channel.Close();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~Proxy() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
	#endregion

	}
}
