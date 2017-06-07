using System;

namespace Wordclock.Shared.SharedInterfaces
{
	public class SettingsData
	{
		public PowerState State { get; set; }

		public DateTime StartTime { get; set; }

		public TimeSpan UpTime { get; set; }
	}
}
