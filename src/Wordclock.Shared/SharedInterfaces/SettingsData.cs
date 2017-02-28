using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Shared.SharedInterfaces
{
	public class SettingsData
	{
		public bool IsWordclockOn { get; set; }

		public TimeSpan UpTime { get; set; }
	}
}
