using System;
using System.Collections.Generic;
using System.Linq;
using Wordclock.Core.Layout;

namespace Wordclock.Core.RenderEngine
{
	public class PowerStateRenderEngineDecorator : IRenderEngine
	{
		private readonly IRenderEngine _innerRenderEngine;
        private readonly ILayoutFactory _layoutFactory;
        private readonly List<Pixel> _lastRenderedPixels;
		
		public PowerStateRenderEngineDecorator(IRenderEngine innerRenderEngine, ILayoutFactory layoutFactory)
        {
			_innerRenderEngine = innerRenderEngine ?? throw new ArgumentNullException(nameof(innerRenderEngine));
			_layoutFactory = layoutFactory ?? throw new ArgumentNullException(nameof(layoutFactory));
			_lastRenderedPixels = [];
		}

        public void Render(IEnumerable<Pixel> pixelsToRender)
		{
			//Wird hier noch lock benötigt? Semaphore?
			if (IsOn)
				_innerRenderEngine.Render(pixelsToRender);

			_lastRenderedPixels.Clear();
			_lastRenderedPixels.AddRange(pixelsToRender);
		}

		private void PowerOn()
		{
			IsOn = true;
			
			Render(_lastRenderedPixels.ToList());
		}

		private void PowerOff()
		{
			IsOn = false;

			_innerRenderEngine.Render(_layoutFactory.CreateLayout().GetChangedPixels());
		}

		public void TogglePowerState()
		{
			if (IsOn)
				PowerOff();
			else
				PowerOn();
		}

		public bool IsOn { get; private set; }
	}
}
