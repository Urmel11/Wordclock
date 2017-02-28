using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wordclock.Mobile
{
	public class BaseContentPage : ContentPage, IView
	{
		public void ShowError(string message)
		{
			DisplayAlert("Error", message, "OK");
		}

		public void ShowMessages(string message)
		{
			DisplayAlert("Info", message, "OK");
		}
	}
}
