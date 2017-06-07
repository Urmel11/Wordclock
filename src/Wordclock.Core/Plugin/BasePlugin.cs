using Wordclock.Core.Layout;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Core.Plugin
{
	public class BasePlugin
	{
		private IRenderEngine _renderEngine;

		public BasePlugin(PluginLayout layout)
		{
			Layout = layout;
		}

		public void AttachRenderEngine(IRenderEngine engine)
		{
			_renderEngine = engine;
			Render();
		}

		public void DetachRenderEngine()
		{
			_renderEngine = null;
		}

		public void Render()
		{
			_renderEngine?.Render(Layout.GetChangedPixels());
		}

		public PluginLayout Layout { get; private set; }
	}
}
