using System;

namespace Wordclock.Shared.Services
{
	public class InfoData
	{
		public DateTime StartTime { get; set; }

		public TimeSpan UpTime { get; set; }

		public string WordclockVersion { get; set; }
	}
}
