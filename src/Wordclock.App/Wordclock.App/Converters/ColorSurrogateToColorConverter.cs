using System;
using System.Globalization;
using Wordclock.App.Utils;
using Wordclock.Shared;
using Xamarin.Forms;

namespace Wordclock.App.Converters
{
	class ColorSurrogateToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var surrogate = (ColorSurrogate)value;

			return surrogate.ToSystemColor();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var color = (Color)value;

			return color.ToColorSurrogate();
		}
	}
}
