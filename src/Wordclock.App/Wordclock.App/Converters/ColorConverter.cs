using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Wordclock.App.Converters
{
	class ColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var color = (System.Drawing.Color)value;

			return Xamarin.Forms.Color.FromRgb(color.R / 255d, color.G / 255d, color.B / 255d);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var color = (Xamarin.Forms.Color)value;

			return System.Drawing.Color.FromArgb(System.Convert.ToInt32(color.R * 255), System.Convert.ToInt32(color.G * 255), System.Convert.ToInt32(color.B * 255));
		}
	}
}
