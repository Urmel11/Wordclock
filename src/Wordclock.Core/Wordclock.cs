using Wordclock.Core.Layout;
using Wordclock.Core.Plugin;
using Wordclock.Core.PowerManagement;
using Wordclock.Core.RenderEngine;
using Wordclock.Core.Startup;

namespace Wordclock.Core
{
	public class Wordclock
	{
		private static StartupHandlerBase _startupHandler;
		
		public static void Startup(StartupHandlerBase startupHandler)
		{
			_startupHandler = startupHandler;
			_startupHandler.Startup();

			var proxy = new RenderManager(_startupHandler.CreateRenderEngine(), new DefaultLayoutBuilder());

			RenderEngine = proxy;
			PluginHandler = new PluginManager(RenderEngine, new DefaultLayoutBuilder());

			TimeSlotStore = new XMLTimeSlotStore();
			TimeSlotManager = new TimeSlotManager(RenderEngine, TimeSlotStore, new TimeProvider());

			PluginHandler.ChangeActivePlugin<Clock>();				
		}

		public static void Shutdown()
		{
			_startupHandler.Shutdown();
		}

		public static RenderManager RenderEngine { get; private set; }
	
		public static PluginManager PluginHandler { get; private set; }
			
		public static ITimeSlotStore TimeSlotStore { get; private set; }

		public static TimeSlotManager TimeSlotManager { get; private set; }
	}
}
