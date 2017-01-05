using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Core.PowerManagement
{
	public class PowerSetting
	{
		public DayOfWeek Weekday { get; set; }

		public DateTime From { get; set; }

		public DateTime To { get; set; }

		public PowerState State { get; set; }
	}
}
