using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;
using Wordclock.Base.RenderEngine;
using Wordclock.Core.Startup;
using Wordclock.ManagementService;
using Wordclock.WSRenderEngine;

namespace Wordclock.TestConsole
{
	class ConsoleStartupHandler : StartupHandlerBase
	{
		public ConsoleStartupHandler()
		{
			AddStartupCommand(new ManagementStartupCommand());
			//AddStartupCommand(new WebserverStartupCommand());
		}

		public override IRenderEngine CreateRenderEngine()
		{
			return new ConsoleRenderEngine(new DefaultLayoutBuilder());
		}
	}
}
