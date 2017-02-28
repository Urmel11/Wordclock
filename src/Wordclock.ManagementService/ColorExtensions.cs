using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.ManagementService
{
	static class ColorExtensions
	{
		public static ColorSurrogate ToColorSurrogate(this System.Drawing.Color color)
		{
			var result = new ColorSurrogate();

			result.R = color.R;
			result.G = color.G;
			result.B = color.B;

			return result;
		}
	}
}
