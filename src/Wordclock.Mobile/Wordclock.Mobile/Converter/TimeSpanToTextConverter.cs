using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wordclock.Mobile.Converter
{
	class TimeSpanToTextConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var uptime = (TimeSpan)value;
						
			int days = GetInterval(uptime, 24*60*60);
			uptime = uptime.Subtract(new TimeSpan(days, 0, 0, 0));

			int hours = GetInterval(uptime, 60*60);
			uptime = uptime.Subtract(new TimeSpan(hours, 0, 0));

			int minutes = GetInterval(uptime, 60);

			var result = "{0:N0} Tage{1}{2:N0} Stunden{1}{3:N0} Minuten{1}";

			result = string.Format(result, days, "\r\n", hours, minutes);

			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		private int GetInterval(TimeSpan uptime, int unit)
		{
			return (int)Math.Floor(uptime.TotalSeconds / unit);
		}
	}
}
