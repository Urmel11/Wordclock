using Wordclock.Core.Layout;
using Wordclock.Core.RenderEngine;
using Wordclock.Core.Startup;
using Wordclock.Core.WordclockManagement;

namespace Wordclock.TestConsole
{
	class ConsoleStartupHandler : StartupHandlerBase
	{
		public ConsoleStartupHandler()
		{
			AddStartupCommand(new ManagementStartupCommand());
		}

		public override IRenderEngine CreateRenderEngine()
		{
			return new ConsoleRenderEngine(new DefaultLayoutBuilder());
		}
	}
}
