using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Shared.SharedInterfaces
{
	public class ClockSettings
	{
		public ColorSurrogate ClockColor { get; set; }
		
		public bool UseSuffix { get; set; }
	}
}
