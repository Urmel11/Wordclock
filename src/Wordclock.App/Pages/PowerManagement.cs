using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordclock.App.Components;
using Wordclock.Core.PowerManagement;

namespace Wordclock.App.Pages
{
	public partial class PowerManagement
	{
		public PowerManagement()
		{
			TimeSlots = new List<PowerTimeSlot>()
			{
				new PowerTimeSlot(){DayOfWeek = DayOfWeek.Monday, EndTime = TimeSpan.FromMinutes(60*12), StarTime=TimeSpan.FromMinutes(0)},
				new PowerTimeSlot(){DayOfWeek = DayOfWeek.Tuesday, EndTime = TimeSpan.FromMinutes(60*5), StarTime=TimeSpan.FromMinutes(0)},
				new PowerTimeSlot(){DayOfWeek = DayOfWeek.Wednesday, EndTime = TimeSpan.FromHours(23), StarTime=TimeSpan.FromHours(16)}
			};
		}

		private void AddTimeSlotDetail()
		{
			TimeSlotDetailDialog.Show();
		}

		public List<PowerTimeSlot> TimeSlots { get; set; }
		public TimeSlotDetailDialog TimeSlotDetailDialog { get; set; }
	}
}
