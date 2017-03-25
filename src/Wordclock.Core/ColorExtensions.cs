using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;

namespace Wordclock.Core
{
	static class ColorExtensions
	{
		public static System.Drawing.Color ToColor(this ColorSurrogate surrogate)
		{
			return System.Drawing.Color.FromArgb(surrogate.R, surrogate.G, surrogate.B);
		}

		public static ColorSurrogate ToColorSurrogate(this System.Drawing.Color col)
		{
			return new ColorSurrogate()
			{
				R = col.R,
				G = col.G,
				B = col.B
			};
		}
	}
}
