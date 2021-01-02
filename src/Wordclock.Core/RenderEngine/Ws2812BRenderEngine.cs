using Iot.Device.Ws28xx;
using System;
using System.Collections.Generic;
using System.Device.Spi;
using Wordclock.Core.Layout;
using Wordclock.Core.Startup;

namespace Wordclock.Core.RenderEngine
{
	/// <summary>
	/// Render engine uses wrapper functionality to communicate with the WS281x controller
	/// </summary>
	class Ws2812BRenderEngine : IRenderEngine, IDisposable
	{
		private SpiDevice _spiDevice;
		private Ws2812b _device;
		private bool disposedValue;

		public Ws2812BRenderEngine()
		{
			SpiConnectionSettings settings = new(0, 0)
			{
				ClockFrequency = 2_400_000,
				Mode = SpiMode.Mode0,
				DataBitLength = 8
			};

			_spiDevice = SpiDevice.Create(settings);
			_device = new Ws2812b(_spiDevice, 140);
		}

		public void Render(IEnumerable<Pixel> pixelsToRender)
		{
			var image = _device.Image;

			foreach (var p in pixelsToRender)
			{
				image.SetPixel(p.PixelID, 0, p.PixelColor);
			}

			_device.Update();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_spiDevice.Dispose();
				}

				// TODO: Nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer überschreiben
				// TODO: Große Felder auf NULL setzen
				disposedValue = true;
			}
		}

		// // TODO: Finalizer nur überschreiben, wenn "Dispose(bool disposing)" Code für die Freigabe nicht verwalteter Ressourcen enthält
		// ~Ws2812BRenderEngine()
		// {
		//     // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
		//     Dispose(disposing: false);
		// }

		public void Dispose()
		{
			// Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
