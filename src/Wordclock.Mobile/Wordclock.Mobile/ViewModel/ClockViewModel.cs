using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.SharedInterfaces;
using Xamarin.Forms;
using Wordclock.Mobile.Helpers;

namespace Wordclock.Mobile.ViewModel
{
	class ClockViewModel
	{
		private IMessageAlerter _alerter;

		public ClockViewModel(IMessageAlerter alerter)
		{
			_alerter = alerter;
			InitializeData();
		}

		private void InitializeData()
		{
			var instance = ServiceConnector.CreateInstance<IClockService>();
			try
			{
				Settings = instance.GetWordclockSettings();
			}
			catch(Exception ex)
			{
				_alerter.ShowError(ex);
			}
		}

		private void SetShowPrefix(bool value)
		{
			try
			{
				var instance = ServiceConnector.CreateInstance<IClockService>();

				instance.SetShowPrefix(value);
			}
			catch(Exception ex)
			{
				_alerter.ShowError(ex);
			}
		}

		public void SetClockColor(Color color)
		{
			var instance = ServiceConnector.CreateInstance<IClockService>();
			
			try
			{
				instance.SetClockColor(color.ToColorSurrogate());
			}
			catch(Exception ex)
			{
				_alerter.ShowError(ex);
			}
		}

		public ClockSettings Settings { get; set; }

		public bool ShowPrefix
		{
			get
			{
				return Settings.ShowPrefix;
			}
			set
			{
				SetShowPrefix(value);
			}
		}
	}
}
