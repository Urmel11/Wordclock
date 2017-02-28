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
	public partial class WordclockPage : BaseContentPage, IColorSelected
	{
		public WordclockPage()
		{
			BindingContext = new WordclockPageViewModel(this);
			InitializeComponent();
		}

		public void OnColorSelected(ColorDefinition selectedColor)
		{
			
		}

		public void OnTapped(object sender, EventArgs e)
		{
			var picker = new ColorPickerPage(this);
			Navigation.PushModalAsync(picker, true);
		}
	}
}
