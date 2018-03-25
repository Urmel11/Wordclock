using rpi_ws281x;
using System.Collections.Generic;
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
		//It is important to dispose the object to cleanup unmanaged memory
		private WS281x _ws281x;

		public void Render(IEnumerable<Pixel> pixelsToRender)
		{

			foreach(var p in pixelsToRender)
			{
				_ws281x.SetLEDColor(0, p.PixelID, p.PixelColor);
			}

			_ws281x.Render();
		}

		public void Shutdown()
		{
			_ws281x?.Dispose();
		}

		public void Startup()
		{
			var settings = Settings.CreateDefaultSettings();

			settings.Channels[0] = new Channel(140, 18, 255, false, StripType.WS2812_STRIP);

			_ws281x = new WS281x(settings);
		}
	}
}
