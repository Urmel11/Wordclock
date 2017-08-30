using Prism.Navigation;
using Plugin.Settings.Abstractions;
using System;
using System.Threading.Tasks;
using Wordclock.App.ClientProxy;
using Wordclock.App.Utils;
using Wordclock.Shared.SharedInterfaces;
using Xamarin.Forms;

namespace Wordclock.App.ViewModels
{
	public class ConnectPageViewModel : ProgressBaseViewModel
	{
		private string _server;
		private int _port;

		private INavigationService _navigationService;
		private IWordclockDialogService _dialogService;
		private ISettings _settingsService;
		private IConnectionService _connectionService;

		public ConnectPageViewModel(INavigationService navigationService,
									IWordclockDialogService dialogSerivce,
									ISettings settingsService,
									IConnectionService connectionService)
		{
			_navigationService = navigationService;
			_dialogService = dialogSerivce;
			_settingsService = settingsService;
			_connectionService = connectionService;
			
			Connect = new Command(async () => await ConnectToWordclock(), () => !IsBusy);

			LoadConnectionInformation();
		}

		/// <summary>
		/// Tries to establish a connection to the wordclock
		/// </summary>
		/// <returns></returns>
		async Task ConnectToWordclock()
		{
			bool isInputValid = await ValidateUserInput();
			
			if (isInputValid)
			{
				IsBusy = true;
				Connect.ChangeCanExecute();

				var isConnectionEstablished = false;

				try
				{
					EndpointConfigurationFactory.Initialize(_server, _port);
					isConnectionEstablished = await Task.Run(() => _connectionService.IsConnectionEstablished());
				}
				catch(Exception ex)
				{
					await _dialogService.ShowError(ex);
				}
				finally
				{
					IsBusy = false;
					Connect.ChangeCanExecute();
				}

				if (isConnectionEstablished)
				{
					SaveConnectionInformation();
					
					//Use absolute Uri to reset the navigation stack. So it is not possible to navigate to the ConnectPage anymore
					await _navigationService.NavigateAsync(new Uri("/MenuPage", UriKind.Absolute));
				}
			}
		}
		
		/// <summary>
		/// Saves the connection information to load them the next time the view is shown
		/// </summary>
		private void SaveConnectionInformation()
		{
			_settingsService.AddOrUpdateValue(nameof(Port), _port);
			_settingsService.AddOrUpdateValue(nameof(Server), _server);
		}

		/// <summary>
		/// Load connection information
		/// </summary>
		private void LoadConnectionInformation()
		{
			_port = _settingsService.GetValueOrDefault(nameof(Port), 0);
			_server = _settingsService.GetValueOrDefault(nameof(Server), "");
		}

		/// <summary>
		/// Validates the user input
		/// </summary>
		/// <returns>Returns a value which indicates if server and port are correct</returns>
		private async Task<bool> ValidateUserInput()
		{
			var isValidInput = true;

			isValidInput = isValidInput && !string.IsNullOrWhiteSpace(Server);
			isValidInput = isValidInput && (Port > 0);

			if(!isValidInput)
			{
				await _dialogService.ShowError("Ungültige Adresse oder Port.");
			}

			return isValidInput;
		}

		public Command Connect { get; private set; }

		/// <summary>
		/// Gets or sets the port
		/// </summary>
		public int Port
		{
			get { return _port; }
			set { SetProperty(ref _port, value); }
		}

		/// <summary>
		/// Gets or sets the address of the wordclock
		/// </summary>
		public string Server
		{
			get { return _server; }
			set { SetProperty(ref _server, value); }
		}
	}
}
