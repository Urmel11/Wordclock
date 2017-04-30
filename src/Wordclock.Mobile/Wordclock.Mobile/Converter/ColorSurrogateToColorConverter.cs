using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;
using Xamarin.Forms;
using Wordclock.Mobile.Helpers;

namespace Wordclock.Mobile.Converter
{
	class ColorSurrogateToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var surrogate = (ColorSurrogate)value;

			return surrogate.ToColor();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var color = (Color)value;

			return color.ToColorSurrogate();
		}
	}
}
