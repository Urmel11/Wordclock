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
	public partial class ClockView : ContentPage, IColorPickerObserver
	{
		private const string CLOCK_COLOR_KEY = "clockColor";

		public ClockView()
		{
			BindingContext = new ClockViewModel(new MessageAlerter());
			InitializeComponent();
		}

		public void Apply(Color selectedColor, string key)
		{
			switch(key)
			{
				case CLOCK_COLOR_KEY:
					SetClockColor(selectedColor);
					break;
			}
		}

		public void PopPage()
		{
			Navigation.PopModalAsync();
		}

		private void SetClockColor(Color color)
		{
			var model = BindingContext as ClockViewModel;
			clockColor.Color = color;
			model.SetClockColor(color);
		}

		private void ColorCellTapped(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new ColorPickerView(clockColor.Color, CLOCK_COLOR_KEY, this));
		}
	}
}
