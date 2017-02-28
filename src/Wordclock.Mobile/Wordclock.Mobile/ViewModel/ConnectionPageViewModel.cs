using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wordclock.Shared.SharedInterfaces;
using Xamarin.Forms;

namespace Wordclock.Mobile.ViewModel
{
	class ConnectionPageViewModel
	{
		private IView _view;
		private INavigation _navigator;

		public ConnectionPageViewModel(IView view, INavigation navigator)
		{
			_view = view;
			_navigator = navigator;
			Connect = new Command(ExecuteConnect);

			Server = "desktop-cu9micq";
			Port = 6840;
		}
				
		public void ExecuteConnect(object o)
		{
			if(IsInputValid())
			{
				if(TestConnection())
				{
					ShowMainPage();
				}
			}
			else
			{
				_view.ShowError("Die Adresse oder der Port ist ungültig.");
			}
		}

		private bool TestConnection()
		{
			ServiceConnector.Server = Server;
			ServiceConnector.Port = Port;

			var instance = ServiceConnector.CreateInstance<IWordclockService>();

			try
			{
				return instance.IsConnectionEstablished();
			}
			catch(Exception ex)
			{
				_view.ShowError(ex.ToString());
				return false;
			}
			
		}

		private void ShowMainPage()
		{
			_navigator.InsertPageBefore(new MenuPage(), _navigator.NavigationStack.Last());
			_navigator.PopAsync();
		}

		private bool IsInputValid()
		{
			return !String.IsNullOrEmpty(Server) && (Port > 0);
		}

		public ICommand Connect { get; private set; }

		public string Server { get; set; }
		public int Port { get; set; }

	}
}
