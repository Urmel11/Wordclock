using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Performing startuphandler");

				Core.Wordclock.Startup(new ConsoleStartupHandler());
				Console.WriteLine("Startuphandler completed");

				while (true) ;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
				
			Console.ReadLine();
			Console.WriteLine("Shutdown ausführen");

			Core.Wordclock.Shutdown();

			Console.WriteLine("Shutodown fertig");
		}
	}
}
