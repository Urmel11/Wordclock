using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Core.Startup
{
	public interface IStartupCommand
	{
		void Startup();

		void Shutdown();
	}
}
