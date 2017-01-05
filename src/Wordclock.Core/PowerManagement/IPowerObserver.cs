using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Core.PowerManagement
{
	interface IPowerObserver
	{
		void PowerOn();

		void PowerOff();
	}
}
