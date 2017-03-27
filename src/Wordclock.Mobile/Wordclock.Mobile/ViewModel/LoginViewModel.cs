using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wordclock.Shared.SharedInterfaces;
using Xamarin.Forms;
using Wordclock.Mobile.Helpers;

namespace Wordclock.Mobile.ViewModel
{
    class LoginViewModel
    {
		private IMessageAlerter _messageAlerter;
		private INavigation _navigator;

		public LoginViewModel(INavigation nav, IMessageAlerter alerter)
		{
			_navigator = nav;
			_messageAlerter = alerter;
			Login = new Command(ExecuteLogin);

			LoadLogin();
		}

		public void ExecuteLogin(object o)
		{
			if(IsIntputValid())
			{
				if(InitializeConnection())
				{
					SaveLogin();
					ShowMainPage();
				}
			}
			else
			{
				_messageAlerter.ShowError("Die Adresse order der Port ist ungültig.");
			}
		}

		private void ShowMainPage()
		{
			_navigator.InsertPageBefore(new View.MainView(), _navigator.NavigationStack.Last());
			_navigator.PopAsync();
		}

		private void SaveLogin()
		{
			Settings.Server = Server;
			Settings.Port = Port;
		}

		private void LoadLogin()
		{
			Server = Settings.Server;
			Port = Settings.Port;
		}

		private bool InitializeConnection()
		{
			ServiceConnector.Initialize(Server, Port);
			var instance = ServiceConnector.CreateInstance<IWordclockService>();

			try
			{
				return instance.IsConnectionEstablished();
			}
			catch(Exception ex)
			{
				_messageAlerter.ShowError(ex);
				return false;
			}
		}

		private bool IsIntputValid()
		{
			return !String.IsNullOrEmpty(Server) && (Port > 0);
		}

		public ICommand Login { get; private set; }

		public string Server { get; set; }
		public int Port { get; set; }
    }
}
