using Wordclock.Core.Layout;
using Wordclock.Core.Plugin;
using Wordclock.Core.PowerManagement;
using Wordclock.Core.RenderEngine;
using Wordclock.Core.Startup;
using Wordclock.Core.Utils;

namespace Wordclock.Core
{
	public class Wordclock
	{
		private static StartupHandlerBase? _startupHandler;
		
		public static void Startup(StartupHandlerBase startupHandler)
		{
			_startupHandler = startupHandler;
			_startupHandler.Startup();

			RenderManager proxy = new RenderManager(_startupHandler.CreateRenderEngine(), new DefaultLayoutBuilder());

			RenderEngine = proxy;
			PluginHandler = new PluginManager(RenderEngine, new DefaultLayoutBuilder());

			TimeSlotManager = new TimeSlotManager(RenderEngine, new WordclockTimer(1000 * 60), new TimeProvider(), new TimeSlotStoreDecorator(new XMLTimeSlotStore()));

			PluginHandler.ChangeActivePlugin<Clock>();				
		}

		public static void Shutdown()
		{
			_startupHandler?.Shutdown();
		}

		public static RenderManager? RenderEngine { get; private set; }
	
		public static PluginManager? PluginHandler { get; private set; }
		
		public static TimeSlotManager? TimeSlotManager { get; private set; }
	}
}
