using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;
using Xamarin.Forms;

namespace Wordclock.Mobile.Helpers
{
	static class ColorExtensions
	{
		public static Color ToColor(this ColorSurrogate surrogate)
		{
			return Color.FromRgb(surrogate.R, surrogate.G, surrogate.B);
		}

		public static ColorSurrogate ToColorSurrogate(this Color color)
		{
			
			return new ColorSurrogate()
			{
				R = System.Convert.ToByte(color.R * 255),
				G = System.Convert.ToByte(color.G * 255),
				B = System.Convert.ToByte(color.B * 255)
			};
		}
	}
}
