using System.Collections.Generic;
using System.ComponentModel;
using Wordclock.Core.Layout;
using Wordclock.Core.PowerManagement;
using Wordclock.Core.RenderEngine;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.Core
{
	public class RenderProxy : IRenderEngine, IPowerObserver
	{
		private IRenderEngine _renderEngine;
		private static object _syncRoot = new object();
		private PixelTracker _pixelTracker;
		private PowerState _powerState;
		private ILayoutBuilder _layoutBuilder;

		public RenderProxy(IRenderEngine engine, ILayoutBuilder layoutBuilder)
		{
			_renderEngine = engine;
			_pixelTracker = new PixelTracker();
			_powerState = PowerState.On;
			_layoutBuilder = layoutBuilder;
		}

		public void Render(IEnumerable<Pixel> pixelsToRender)
		{
			lock (_syncRoot)
			{
				//Remember the active pixels
				_pixelTracker.Track(pixelsToRender);

				if(_powerState == PowerState.On)
				{
					_renderEngine.Render(pixelsToRender);
				}
				
				foreach (IChangeTracking p in pixelsToRender)
				{
					p.AcceptChanges();
				}
			}
		}

		public void PowerOn()
		{
			_powerState = PowerState.On;

			Render(_pixelTracker.GetActivePixels());
		}

		public void PowerOff()
		{
			var pixels = new List<Pixel>();
			//Create a new layout to get empty pixels
			pixels.AddRange(_layoutBuilder.CreateAmbilight().GetChangedPixels());
			pixels.AddRange(_layoutBuilder.CreateLayout().GetChangedPixels());

			_pixelTracker.IsTrackingAllowed = false;
			Render(pixels);
			_pixelTracker.IsTrackingAllowed = true;

			_powerState = PowerState.Off;
		}
	}
}
