using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Wordclock.Base.RenderEngine;
using Wordclock.Base.Layout;

namespace Wordclock.WSRenderEngine
{
	public class WebserviceRenderEngine : IRenderEngine
	{
		RenderService.Application _application;

		/// <summary>
		/// Initialize the engine
		/// </summary>
		public WebserviceRenderEngine()
		{
			_application = new RenderService.Application();
			Initialize();
			
		}

		/// <summary>
		/// REnder the given layout
		/// </summary>
		/// <param name="layout"></param>
		public void Render(IEnumerable<Pixel> pixelsToRender)
		{
			//Process only changed pixels. This will speed up the performance
			//All pixels with the same color are grouped
			List<List<Pixel>> ChangedPixels = pixelsToRender
												.GroupBy(x => x.PixelColor)
												.Select(grp => grp.ToList()).ToList();

			string RenderOptions = "";

			for (int i = 0; i <= ChangedPixels.Count - 1; i++)
			{
				//To minimize the calls to the python webservice, all changed pixels and colors are
				//transferred in one batch. The string has following format:
				//ColorRed:ColorGreen:ColorBlue:pixel1,pixel2-Segment with new color
				RenderOptions += ChangedPixels[i].First().PixelColor.R.ToString() + ":";
				RenderOptions += ChangedPixels[i].First().PixelColor.G.ToString() + ":";
				RenderOptions += ChangedPixels[i].First().PixelColor.B.ToString() + ":";
				RenderOptions += String.Join(",", ChangedPixels[i].Select(x => x.PixelID)) + "-";
			}

			//Transfer the changed pixels in one batch to the python webservice
			//The layout is rendered immediately
			var Renderer = new RenderService.setPixelAndRender()
			{
				renderString = RenderOptions.TrimEnd('-')
			};
			_application.setPixelAndRender(Renderer);
		}

		/// <summary>
		/// Initialize the neo pixel strip
		/// </summary>
		private void Initialize()
		{
			var Init = new RenderService.initialize()
			{
				ledCount = "140",
				ledPin = "18",
				ledFrequence = "800000",
				ledDMA = "5",
				ledBrightness = "255"
			};
			_application.initialize(Init);
		}
	}
}
