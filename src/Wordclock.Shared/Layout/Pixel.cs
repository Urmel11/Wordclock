using System.ComponentModel;
using System;

namespace Wordclock.Base.Layout
{
	/// <summary>
	/// Class which represents one pixel
	/// </summary>
	public class Pixel : IChangeTracking
	{
		private ColorSurrogate _pixelColor;
		private bool _isChanged;
	
		public Pixel(int pixelID)
		{
			PixelColor = new ColorSurrogate();
			PixelID = pixelID;
			_isChanged = true;
		}
		/// <summary>
		/// ID of the pixel 
		/// </summary>
		public int PixelID { get; private set; }
		

		/// <summary>
		/// Gets or sets the color
		/// </summary>
		public ColorSurrogate PixelColor
		{
			get { return _pixelColor; }
			set
			{ 
				if(!value.Equals(_pixelColor))
				{
					_pixelColor = value;
					_isChanged = true;
				}
			}
		}

		public void Clear()
		{
			PixelColor = new ColorSurrogate();
		}
				
		/// <summary>
		/// Indicates if the object changed
		/// </summary>
		public bool IsChanged
		{
			get { return _isChanged; }
		}
	
		/// <summary>
		/// Accept all the changes
		/// </summary>
		public void AcceptChanges()
		{
			_isChanged = false;
		}
	}
}
