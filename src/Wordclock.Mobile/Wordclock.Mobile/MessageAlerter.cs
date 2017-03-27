using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Mobile
{
    class MessageAlerter : IMessageAlerter
    {
        public void ShowError(string message)
        {
            App.Current.MainPage.DisplayAlert("Error", message, "Ok");
        }

        public void ShowError(Exception ex)
        {
            App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
        }

        public void ShowMessage(string message)
        {
            App.Current.MainPage.DisplayAlert("Info", message, "Ok");
        }
    }
}
