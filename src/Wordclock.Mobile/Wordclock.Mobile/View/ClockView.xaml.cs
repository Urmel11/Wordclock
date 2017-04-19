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

		private void ColorCellTapped(object sender, EventArgs e)
		{
			var currentColor = ((ClockViewModel)BindingContext).Settings.ClockColor;

			
			Navigation.PushModalAsync(new ColorPickerView(Color.FromRgb(currentColor.R, currentColor.G, currentColor.B)));
		}
	}
}
