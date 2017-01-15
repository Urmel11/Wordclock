using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.RenderEngine;
using Wordclock.Core.Plugin;
using Wordclock.Core.Startup;
using Wordclock.Base.Layout;
using System.Xml.Serialization;
using System.IO;

namespace Wordclock.Core
{
	public class Wordclock
	{
		private static StartupHandlerBase _startupHandler;
		
		public static void Startup(StartupHandlerBase startupHandler)
		{
			_startupHandler = startupHandler;
			_startupHandler.Startup();

			var proxy = new RenderProxy(_startupHandler.CreateRenderEngine(), new DefaultLayoutBuilder());

			RenderEngine = proxy;
			PluginHandler = new PluginManager(RenderEngine, new DefaultLayoutBuilder());

			PowerManager = new PowerManagement.PowerManager(proxy);

			PluginHandler.ChangeActivePlugin<Clock>();				
		}

		public static void Shutdown()
		{
			_startupHandler.Shutdown();
		}

		public static IRenderEngine RenderEngine { get; private set; }
	
		public static PluginManager PluginHandler { get; private set; }

		public static PowerManagement.PowerManager PowerManager { get; private set; }
	
	}
}
