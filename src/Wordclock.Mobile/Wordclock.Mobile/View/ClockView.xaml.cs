using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wordclock.Mobile.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClockView : ContentPage
	{
		public ClockView()
		{
			BindingContext = new ClockViewModel(new MessageAlerter());
			InitializeComponent();
		}
	}
}
