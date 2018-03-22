using Wordclock.Core.RenderEngine;
using Wordclock.Core.Startup;
using Wordclock.Core.WordclockManagement;

namespace Wordclock
{
	class StartupHandler : StartupHandlerBase
	{
		private RenderEngine _renderEngine;

		public StartupHandler()
		{
			_renderEngine = new RenderEngine();

			AddStartupCommand(new ManagementStartupCommand());
			AddStartupCommand(_renderEngine);
		}

		public override IRenderEngine CreateRenderEngine()
		{
			return _renderEngine;
		}
	}
}
