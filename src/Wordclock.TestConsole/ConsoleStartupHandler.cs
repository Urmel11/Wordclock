using Wordclock.Core.Layout;
using Wordclock.Core.RenderEngine;
using Wordclock.Core.Startup;

namespace Wordclock.TestConsole
{
	class ConsoleStartupHandler : StartupHandlerBase
	{

		public override IRenderEngine CreateRenderEngine()
		{
			return new ConsoleRenderEngine(new DefaultLayoutBuilder());
		}
	}
}
