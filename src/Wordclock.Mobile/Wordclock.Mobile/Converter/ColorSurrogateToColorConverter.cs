using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;
using Xamarin.Forms;

namespace Wordclock.Mobile.Converter
{
	class ColorSurrogateToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var surrogate = (ColorSurrogate)value;

			return Color.FromRgb(surrogate.R, surrogate.G, surrogate.B);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var color = (Color)value;
			
			return new ColorSurrogate()
			{
				R = System.Convert.ToByte(color.R),
				G = System.Convert.ToByte(color.G),
				B = System.Convert.ToByte(color.B)
			};
		}
	}
}
