using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.SharedInterfaces;
using Xamarin.Forms;

namespace Wordclock.Mobile.Converter
{
	class PowerStateToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var state = (PowerState) value;

			if(state == PowerState.On)
			{
				return true;
			}

			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var isOn = (bool)value;

			if(isOn)
			{
				return PowerState.On;
			}

			return PowerState.Off;
		}
	}
}
