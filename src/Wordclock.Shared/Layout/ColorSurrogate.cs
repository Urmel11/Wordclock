using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Base.Layout
{
	public class ColorSurrogate : IEquatable<ColorSurrogate>
	{
		public ColorSurrogate()
		{
			R = 0;
			G = 0;
			B = 0;
		}

		public byte R { get; set; }
		public byte G { get; set; }
		public byte B { get; set; }

		public bool Equals(ColorSurrogate other)
		{
			if(other == null)
			{
				return false;
			}

			return (this.R == other.R) &&
					(this.G == other.G) &&
					(this.B == other.B);
		}
	}
}
