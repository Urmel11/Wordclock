using System;
using System.Globalization;
using Wordclock.Mobile.Helpers;
using Wordclock.Shared;
using Xamarin.Forms;

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
