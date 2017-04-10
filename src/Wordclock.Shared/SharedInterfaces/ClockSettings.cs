using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;

namespace Wordclock.Shared.SharedInterfaces
{
	public class ClockSettings
	{
		public ColorSurrogate ClockColor { get; set; }
		
		public bool ShowPrefix { get; set; }
	}
}
