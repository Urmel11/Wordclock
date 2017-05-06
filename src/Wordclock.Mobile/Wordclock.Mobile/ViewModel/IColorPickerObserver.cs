using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wordclock.Mobile.ViewModel
{
	public interface IColorPickerObserver
	{
		void PopPage();

		void Apply(Color selectedColor, string key);
	}
}
