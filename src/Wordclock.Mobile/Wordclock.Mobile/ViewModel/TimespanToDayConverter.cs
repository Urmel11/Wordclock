using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wordclock.Mobile.ViewModel
{
	class TimespanToDayConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var timespan = (TimeSpan)value;
			var result = "{0:N0} Tage{1}{2:N0} Stunden{1}{3:N0} Minuten{1}";

			result = string.Format(result, timespan.TotalDays, "\r\n", timespan.TotalHours, timespan.TotalMinutes);

			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
