using Wordclock.Shared;
using Xamarin.Forms;

namespace Wordclock.App.Utils
{
	static class ColorExtensions
	{
		public static Color ToSystemColor(this ColorSurrogate surrogate)
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
