using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordclock.Core.PowerManagement;

namespace Wordclock.App.Components
{
	public partial class TimeSlotDetailDialog
	{
		public TimeSlotDetailDialog()
		{
			TimeSlot = new PowerTimeSlot();
		}

		public void Show()
		{
			TimeSlot = new PowerTimeSlot();
			ShowDialog = true;
			StateHasChanged();
		}

		public void Close()
		{
			ShowDialog = false;
			StateHasChanged();
		}

		public PowerTimeSlot TimeSlot { get; set; }

		public bool ShowDialog { get; private set; }

	}
}
