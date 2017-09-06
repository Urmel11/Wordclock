using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Shared.Services
{
	public class PowerTimeSlot
	{
		public DayOfWeek DayOfWeek { get; set; }

		public DateTime StarTime { get; set; }

		public DateTime EndTime { get; set; }

		public string Test
		{
			get
			{
				return DayOfWeek.ToString();
			}
		}
	}
}
