using Prism.Mvvm;

namespace Wordclock.App.Models
{
	public class ColorPickerColor : BindableBase
	{
		private int _green, _blue, _red;

		System.Drawing.Color _color;
		public System.Drawing.Color Color
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

		public int Red
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

		public int Green
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

		public int Blue
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
			Color = System.Drawing.Color.FromArgb(Red, Green, Blue);
		}

	}
}
