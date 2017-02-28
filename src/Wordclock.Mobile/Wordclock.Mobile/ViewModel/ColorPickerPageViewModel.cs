using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.Model;
using Xamarin.Forms;

namespace Wordclock.Mobile.ViewModel
{
	class ColorPickerPageViewModel
	{
		public ColorPickerPageViewModel()
		{
			AvailableColors = new List<ColorDefinition>();
			
			InitializeAvailableColor();
		}

		public List<ColorDefinition> AvailableColors { get; private set; }

		private void InitializeAvailableColor()
		{
			var colors = GetColors();

			foreach(var color in colors)
			{
				AvailableColors.Add(new ColorDefinition() { Name = color.Key, Color = color.Value });
			}
		}

		private Dictionary<string, Color> GetColors()
		{			
			var map = new Dictionary<string, Color>();
			var colorType = typeof(Color);

			var fields = colorType.GetRuntimeFields();

			fields = fields.Where(x => x.IsStatic && x.IsPublic).ToList();
			
			foreach(var field in fields)
			{
				var colorName = field.Name;
				map[colorName] = (Color)colorType.GetRuntimeField(colorName).GetValue(new Color());
			}

			return map;
		}
	}
}
