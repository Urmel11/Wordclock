using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.SharedInterfaces;
using Xamarin.Forms;

namespace Wordclock.Mobile
{
	public partial class ConnectionPage : ContentPage
	{
		public ConnectionPage()
		{
			InitializeComponent();
		}

		private void OnClick(object o, EventArgs e)
		{
			ServiceConnector.Server = txtAddress.Text;
			ServiceConnector.Port = Convert.ToInt32(txtPort.Text);

			try
			{
				var instance = ServiceConnector.CreateInstance<IWordclockService>();
				//var result = instance.IsConnectionEstablished();

				//DisplayAlert("Success", result.ToString(), "OK");
				
				Navigation.PushModalAsync(new MenuPage());

			}catch (Exception ex)
			{
				DisplayAlert("Error", ex.ToString(), "OK");
			}
		}
	}
}
