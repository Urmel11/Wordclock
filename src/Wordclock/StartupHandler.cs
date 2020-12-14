using Wordclock.Core.RenderEngine;
using Wordclock.Core.Startup;

namespace Wordclock
{
	class StartupHandler : StartupHandlerBase
	{
		private RenderEngine _renderEngine;

		public StartupHandler()
		{
			_renderEngine = new RenderEngine();
			AddStartupCommand(_renderEngine);
		}

		public override IRenderEngine CreateRenderEngine()
		{
			return _renderEngine;
		}
	}
}
