using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.SharedInterfaces;
using Xamarin.Forms;

namespace Wordclock.Mobile.ViewModel
{
	class NumberToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var surrogate = value as ColorSurrogate;
			
			return new Color(surrogate.R, surrogate.G, surrogate.B);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
