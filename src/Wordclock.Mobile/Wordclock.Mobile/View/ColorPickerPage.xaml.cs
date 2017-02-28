using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.Model;
using Wordclock.Mobile.View;
using Wordclock.Mobile.ViewModel;
using Xamarin.Forms;

namespace Wordclock.Mobile
{
	public partial class ColorPickerPage : ContentPage
	{
		private IColorSelected _colorSelected;

		public ColorPickerPage(IColorSelected colorSelected)
		{
			BindingContext = new ColorPickerPageViewModel();
			_colorSelected = colorSelected;
			InitializeComponent();
		}

		public void OnItemTapped(object sender, EventArgs e)
		{
			_colorSelected.OnColorSelected((colorList.SelectedItem as ColorDefinition));
			Navigation.PopAsync();
		}
	}
}
