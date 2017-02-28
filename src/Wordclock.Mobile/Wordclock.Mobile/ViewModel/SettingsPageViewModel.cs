using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.Mobile.ViewModel
{
	class SettingsPageViewModel
	{
		private IView _view;

		public SettingsPageViewModel(IView view)
		{
			_view = view;
			InitializeData();
		}

		private void InitializeData()
		{
			var instance = ServiceConnector.CreateInstance<IWordclockService>();

			try
			{
				Data = instance.Data();
			}
			catch(Exception ex)
			{
				_view.ShowError(ex.ToString());
			}
			
		}

		private void ChangePowerState(bool isOn)
		{
			var instance = ServiceConnector.CreateInstance<IWordclockService>();
			var state = PowerState.On;

			if(!isOn)
			{
				state = PowerState.Off;
			}

			try
			{
				instance.SetPowerState(state);
			}
			catch(Exception ex)
			{
				_view.ShowError(ex.ToString());
			}
		}

		public SettingsData Data { get; set; }

		public bool IsPowerOn
		{
			get
			{
				return Data.IsWordclockOn;
			}
			set
			{
				ChangePowerState(value);
			}
		}
		
	}
}
