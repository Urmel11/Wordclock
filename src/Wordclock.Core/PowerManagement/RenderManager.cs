using System.Collections.Generic;
using System.ComponentModel;
using Wordclock.Core.Layout;
using Wordclock.Core.PowerManagement;
using Wordclock.Core.RenderEngine;
using Wordclock.Shared.Services;

namespace Wordclock.Core
{
	public class RenderManager : IRenderEngine, ITimeSlotObserver
	{
		private IRenderEngine _renderEngine;
		private static object _syncRoot = new object();
		private PixelTracker _pixelTracker;
		private PowerState _powerState;
		private ILayoutBuilder _layoutBuilder;

		public RenderManager(IRenderEngine engine, ILayoutBuilder layoutBuilder)
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
					InternalRender(pixelsToRender);
				}
				
				foreach (IChangeTracking p in pixelsToRender)
				{
					p.AcceptChanges();
				}
			}
		}

		private void InternalRender(IEnumerable<Pixel> pixelsToRender)
		{
			_renderEngine.Render(pixelsToRender);
		}

		public PowerState GetPowerState()
		{
			return _powerState;
		}

		public void SetPowerState(PowerState newState)
		{
			_powerState = newState;

			if(newState == PowerState.On)
			{
				PowerOn();
			}
			else
			{
				PowerOff();
			}
		}

		private void PowerOn()
		{
			Render(_pixelTracker.GetActivePixels());
		}

		private void PowerOff()
		{
			var pixels = new List<Pixel>();
			//Create a new layout to get empty pixels
			pixels.AddRange(_layoutBuilder.CreateAmbilight().GetChangedPixels());
			pixels.AddRange(_layoutBuilder.CreateLayout().GetChangedPixels());
			
			InternalRender(pixels);
		}

		public void PowerStateChanged(PowerState newState)
		{
			SetPowerState(newState);
		}
	}
}
