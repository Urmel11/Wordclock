using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.Model;
using Xamarin.Forms;

namespace Wordclock.Mobile.ViewModel
{
	class ColorPickerViewModel : INotifyPropertyChanged
	{
		private List<ColorDefinition> _colors;
		private Color _currentColor;

		public event PropertyChangedEventHandler PropertyChanged;

		public ColorPickerViewModel(Color initialColor)
		{
			InitializeColorList();
			CurrentColor = initialColor;
		}

		private void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private void InitializeColorList()
		{
			_colors = new List<ColorDefinition>();

			var colorType = typeof(Color);
			var fields = colorType.GetRuntimeFields();

			fields = fields.Where(x => x.IsStatic && x.IsPublic).ToList();
			

			foreach(var field in fields)
			{
				_colors.Add(new ColorDefinition()
				{
					Name = field.Name,
					Color = (Color)colorType.GetRuntimeField(field.Name).GetValue(new Color())
				});
			}
		}
				
		public Color CurrentColor
		{
			get
			{
				return _currentColor;
			}
			set
			{
				if(_currentColor != value)
				{
					_currentColor = value;
					OnPropertyChanged(nameof(CurrentColor));
				}
			}
		}
		
		public double Red
		{
			get
			{
				return CurrentColor.R;
			}
			set
			{
				CurrentColor = Color.FromRgb(value, Green, Blue);
				OnPropertyChanged(nameof(Red));
			}
		}

		public double Green
		{
			get
			{
				return CurrentColor.G;
			}
			set
			{
				CurrentColor = Color.FromRgb(Red, value, Blue);
				OnPropertyChanged(nameof(Green));
			}
		}

		public double Blue
		{
			get
			{
				return CurrentColor.B;
			}
			set
			{
				CurrentColor = Color.FromRgb(Red, Green, value);
				OnPropertyChanged(nameof(Blue));
			}
		}

		public List<ColorDefinition> Colors
		{
			get
			{
				return _colors;
			}
		}
	}
}
