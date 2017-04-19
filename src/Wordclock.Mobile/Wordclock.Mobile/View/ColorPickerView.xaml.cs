using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.Model;
using Wordclock.Mobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wordclock.Mobile.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorPickerView : ContentPage
	{
		public ColorPickerView(Color initialColor)
		{
			BindingContext = new ColorPickerViewModel(initialColor);
			InitializeComponent();
		}

		private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var selectedItem = (ColorDefinition)e.SelectedItem;
			var viewModel = (ColorPickerViewModel)BindingContext;

			viewModel.Red = selectedItem.Color.R;
			viewModel.Green = selectedItem.Color.G;
			viewModel.Blue = selectedItem.Color.B;
		}
	}
}
