using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Core.Startup;

namespace Wordclock.WSRenderEngine
{
	public class WebserverStartupCommand : IStartupCommand
	{
		public void Shutdown()
		{
			try
			{
				var application = new RenderService.Application();

				application.shutdown(new RenderService.shutdown());
			}
			catch
			{
				
			}
		}

		public void Startup()
		{
			Console.WriteLine("Starte Webserver");

			var start = new ProcessStartInfo()
			{
				FileName = "python",
				Arguments = "neopixelWebservice.py",
				UseShellExecute = false
			};
			
			var p = Process.Start(start);
			
			System.Threading.Thread.Sleep(5000);
		}
	}
}
