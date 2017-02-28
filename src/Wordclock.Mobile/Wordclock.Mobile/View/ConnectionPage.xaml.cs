using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.ViewModel;
using Xamarin.Forms;

namespace Wordclock.Mobile
{
	public partial class ConnectionPage : BaseContentPage
	{
		public ConnectionPage()
		{
			BindingContext = new ConnectionPageViewModel(this, Navigation);
			InitializeComponent();
		}
	}
}
