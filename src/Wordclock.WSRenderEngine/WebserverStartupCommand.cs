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
			
			var start = new ProcessStartInfo();

			start.FileName = "python";
			start.Arguments = "neopixelWebservice.py";
			start.UseShellExecute = false;
			//start.RedirectStandardOutput = true;
			//start.RedirectStandardError = true;

			var p = Process.Start(start);

			Console.WriteLine("Webserver gestartet");
						
			//GetOutput(p);
		}

		static void GetOutput(Process p)
		{
			using (var r = p.StandardOutput)
			{
				Console.WriteLine("output:");
				Console.WriteLine(r?.ReadToEnd());
			}

			using (var r = p.StandardError)
			{
				Console.WriteLine("error:");
				Console.WriteLine(r?.ReadToEnd());
			}

		}
	}
}
