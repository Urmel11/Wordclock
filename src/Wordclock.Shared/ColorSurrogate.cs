using System;

namespace Wordclock.Shared
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
