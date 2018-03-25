using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Wordclock.App.Models;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Wordclock.App.ViewModels
{
	public class ColorPickerPageViewModel : BindableBase, INavigationAware
	{
		public const string CURRENT_COLOR_KEY = "currentcolor";
		public const string SELECTED_COLOR_KEY = "selectedcolor";

		private INavigationService _navigationService;

        public ColorPickerPageViewModel(INavigationService navigationService)
        {
			_navigationService = navigationService;

			PickerColor = new ColorPickerColor();
			ApplyCommand = new Command(async () => await Apply());
			CancelCommand = new Command(async () => await Cancel());
        }

		private async Task Cancel()
		{
			await _navigationService.GoBackAsync();
		}

		private async Task Apply()
		{
			var navigationParams = new NavigationParameters();
			navigationParams.Add(SELECTED_COLOR_KEY, PickerColor.Color);

			await _navigationService.GoBackAsync(navigationParams);
		}

		public ColorPickerColor PickerColor { get; set; }
		
		public Command ApplyCommand { get; set; }

		public Command CancelCommand { get; set; }

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey(CURRENT_COLOR_KEY))
			{
				var currentColor = (System.Drawing.Color)parameters[CURRENT_COLOR_KEY];
				PickerColor.Blue = currentColor.B;
				PickerColor.Red = currentColor.R;
				PickerColor.Green = currentColor.G;
			}
		}
	}
}
