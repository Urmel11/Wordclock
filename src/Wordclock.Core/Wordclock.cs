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

			PowerManager = new PowerManagement.PowerManager(proxy, new PowerManagement.FixPowerStore());

			PluginHandler.ChangeActivePlugin<Clock>();

			//XmlSerializer a = new XmlSerializer(typeof(List<PowerManagement.PowerSetting>));
			//PowerManagement.PowerSetting setting = new PowerManagement.PowerSetting();

			//setting.Weekday = DayOfWeek.Wednesday;
			//setting.State = PowerManagement.PowerState.PowerOn;
			//setting.From = new DateTime(1, 1, 1, 15, 0, 0);
			//setting.To = new DateTime(1, 1, 1, 20, 0, 0);

			//var v = new List<PowerManagement.PowerSetting>();
			//v.Add(setting);

			//var s = new StringBuilder();
			//using (var w = new StringWriter(s))
			//{
			//	a.Serialize(w, v);

			//	w.Flush();

			//}
				
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
