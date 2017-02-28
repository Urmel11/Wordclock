using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.Model;

namespace Wordclock.Mobile.View
{
	public interface IColorSelected
	{
		void OnColorSelected(ColorDefinition selectedColor);
	}
}
