using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	public interface ITimeSlotObserver
	{
		void PowerStateChanged(PowerState newState);
	}
}
