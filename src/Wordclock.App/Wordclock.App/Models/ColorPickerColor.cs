using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wordclock.App.Models
{
	public class ColorPickerColor : BindableBase
	{
		private double _green, _blue, _red;

		Color _color;
		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				SetProperty(ref _color, value);
			}
		}

		public double Red
		{
			get
			{
				return _red;
			}
			set
			{
				SetProperty(ref _red, value);
				UpdateColor();
			}
		}

		public double Green
		{
			get
			{
				return _green;
			}
			set
			{
				SetProperty(ref _green, value);
				UpdateColor();
			}
		}

		public double Blue
		{
			get
			{
				return _blue;
			}
			set
			{
				SetProperty(ref _blue, value);
				UpdateColor();
			}
		}

		private void UpdateColor()
		{
			Color = Color.FromRgb(Red, Green, Blue);
		}

	}
}
