using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.Mobile.ViewModel
{
	class SettingsViewModel
	{
		private IMessageAlerter _messageAlerter;

		public SettingsViewModel(IMessageAlerter alerter)
		{
			_messageAlerter = alerter;
			InitializeData();
		}

		private void InitializeData()
		{
			var instance = ServiceConnector.CreateInstance<ISettingsService>();

			try
			{
				Data = instance.Data();
			}
			catch (Exception ex)
			{
				_messageAlerter.ShowError(ex);
			}

		}

		private void ChangePowerState(PowerState newState)
		{
			var instance = ServiceConnector.CreateInstance<ISettingsService>();
		
			try
			{
				instance.SetPowerState(newState);
			}
			catch (Exception ex)
			{
				_messageAlerter.ShowError(ex);
			}
		}

		public SettingsData Data { get; private set; }

		public PowerState PowerState
		{
			get
			{
				return Data.State;
			}
			set
			{
				ChangePowerState(value);
			}
		}
	}
}
