using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.RenderEngine;
using Wordclock.Core.Startup;
using Wordclock.ManagementService;
using Wordclock.WSRenderEngine;

namespace Wordclock
{
	class StartupHandler : StartupHandlerBase
	{
		public StartupHandler()
		{
			AddStartupCommand(new WebserverStartupCommand());
			AddStartupCommand(new ManagementStartupCommand());
		}

		public override IRenderEngine CreateRenderEngine()
		{
			return new WebserviceRenderEngine();
		}
	}
}
