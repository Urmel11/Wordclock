using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Wordclock.App.Utils;
using Wordclock.Shared.Services;

namespace Wordclock.App.ViewModels
{
	public class PowerPageViewModel : BindableBase, IRefreshable
	{
		IPowerService _powerService;
		IWordclockDialogService _dialogService;
		PowerState _powerState;

		public PowerPageViewModel(IPowerService powerService,
									IWordclockDialogService dialogService)
		{
			_powerService = powerService;
			_dialogService = dialogService;

			Refresh();
		}

		public void Refresh()
		{
			try
			{
				PowerTimeSlots = _powerService.GetPowerTimeSlots();
				_powerState = _powerService.GetPowerState();
			}catch(Exception ex)
			{
				_dialogService.ShowError(ex);
			}
			
		}

		private void SetPowerState(PowerState state)
		{
			try
			{
				if(state != _powerState)
				{
					_powerService.SetPowerState(state);
					_powerState = state;
				}
			}
			catch(Exception ex)
			{
				_dialogService.ShowError(ex);
			}
		}
				
		public PowerState PowerState
		{
			get
			{
				return _powerState;
			}
			set
			{
				SetPowerState(value);
			}
		}

		public List<PowerTimeSlot> PowerTimeSlots { get; private set; }
		
	}
}
