using Iot.Device.Ws28xx;
using System;
using System.Collections.Generic;
using System.Device.Spi;
using Wordclock.Core.Layout;
using Wordclock.Core.RenderEngine;
using Wordclock.Core.Startup;

namespace Wordclock
{
	/// <summary>
	/// Render engine uses wrapper functionality to communicate with the WS281x controller
	/// </summary>
	class RenderEngine : IRenderEngine, IStartupCommand
	{
		private SpiDevice _spiDevice;
		private Ws2812b _device;

		public void Render(IEnumerable<Pixel> pixelsToRender)
		{
			var image = _device.Image;

			foreach (var p in pixelsToRender)
			{
				image.SetPixel(p.PixelID, 0, p.PixelColor);
			}

			_device.Update();
		}

		public void Shutdown()
		{
			_spiDevice?.Dispose();
		}

		public void Startup()
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
	}
}
