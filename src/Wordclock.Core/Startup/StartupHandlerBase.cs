using System.Collections.Generic;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Core.Startup
{
	public abstract class StartupHandlerBase
	{
		private List<IStartupCommand> _startupCommands;

		public StartupHandlerBase()
		{
			_startupCommands = new List<IStartupCommand>();
		}

		public void AddStartupCommand(IStartupCommand command)
		{
			_startupCommands.Add(command);
		}

		public void Startup()
		{
			_startupCommands.ForEach(x => x.Startup());
		}

		public void Shutdown()
		{
			_startupCommands.ForEach(x => x.Shutdown());
		}

		public abstract IRenderEngine CreateRenderEngine();
	}
}
