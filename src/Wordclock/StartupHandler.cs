using Wordclock.Core.RenderEngine;
using Wordclock.Core.Startup;
using Wordclock.Core.WordclockManagement;
using Wordclock.WSRenderEngine;

namespace Wordclock
{
	class StartupHandler : StartupHandlerBase
	{
		public StartupHandler()
		{
			AddStartupCommand(new ManagementStartupCommand());
			AddStartupCommand(new WebserverStartupCommand());
		}

		public override IRenderEngine CreateRenderEngine()
		{
			return new WebserviceRenderEngine();
		}
	}
}
