using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Performing startuphandler");

				Core.Wordclock.Startup(new StartupHandler());

				Console.WriteLine("Startuphandler completed");

				while (true) ;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			
			Core.Wordclock.Shutdown();
		}
	}
}
