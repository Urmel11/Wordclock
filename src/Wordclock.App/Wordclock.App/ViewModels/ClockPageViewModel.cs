using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Drawing;
using System.Threading.Tasks;
using Wordclock.App.Utils;
using Wordclock.Shared.Services;
using Xamarin.Forms;

namespace Wordclock.App.ViewModels
{
	public class ClockPageViewModel : BindableBase, INavigationAware
	{
		private IWordclockDialogService _dialogService;
		private IClockService _clockService;
		private INavigationService _navigationService;
		
		public ClockPageViewModel(IWordclockDialogService dialogService,
									IClockService clockService,
									INavigationService navigationService)
		{
			_dialogService = dialogService;
			_clockService = clockService;
			_navigationService = navigationService;
			ChangeClockColorCommand = new Command(async () => await OpenColorPicker());
		}

		private async Task OpenColorPicker()
		{
			var navigationParams = new NavigationParameters();
			navigationParams.Add(ColorPickerPageViewModel.CURRENT_COLOR_KEY, ClockColor);

			await _navigationService.NavigateAsync("ColorPickerPage", navigationParams);
		}

		private void SetShowPrefix(bool value)
		{
			try
			{
				_clockService.SetShowPrefix(value);
			}catch(Exception ex)
			{
				_dialogService.ShowError(ex);
			}
		}

		private bool GetShowPrefix()
		{
			try
			{
				return _clockService.GetShowPrefix();
			}
			catch (Exception ex)
			{
				_dialogService.ShowError(ex);
			}

			return false;
		}
		
		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			if(parameters.ContainsKey(ColorPickerPageViewModel.SELECTED_COLOR_KEY))
			{
				ClockColor = ((System.Drawing.Color)parameters[ColorPickerPageViewModel.SELECTED_COLOR_KEY]);
			}
		}

		private void SetClockColor(System.Drawing.Color color)
		{
			try
			{
				_clockService.SetClockColor(color);
			}
			catch(Exception ex)
			{
				_dialogService.ShowError(ex);
			}
		}

		private System.Drawing.Color GetClockColor()
		{
			try
			{
				return _clockService.GetClockColor();
			}
			catch (Exception ex)
			{
				_dialogService.ShowError(ex);
			}

			return System.Drawing.Color.Empty;
		}

		public bool ShowPrefix
		{
			get
			{
				return GetShowPrefix();
			}
			set
			{
				SetShowPrefix(value);
			}
		}

		public System.Drawing.Color ClockColor
		{
			get
			{
				return GetClockColor();
			}
			set
			{
				SetClockColor(value);
				RaisePropertyChanged();
			}
		}

		public Command ChangeClockColorCommand { get; private set; }
	}
}
