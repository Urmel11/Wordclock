using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Core.PowerManagement
{
	public interface IPowerStore
	{
		PowerState GetPowerState(DateTime date);
	}
}
