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
				Console.WriteLine("Executing startuphandler...");
				Console.WriteLine();
				
				Core.Wordclock.Startup(new ConsoleStartupHandler());

				Console.SetCursorPosition(0, 1);
				Console.WriteLine("Startuphandler completed");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
				
			Console.ReadLine();
			Core.Wordclock.Shutdown();
		}
	}
}
