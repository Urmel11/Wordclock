﻿using System.Drawing;
using System.ComponentModel;
using System;

namespace Wordclock.Base.Layout
{
	/// <summary>
	/// Class which represents one pixel
	/// </summary>
	public class Pixel : IChangeTracking
	{
		private Color _pixelColor;
		private bool _isChanged;
	
		public Pixel(int pixelID)
		{
			PixelColor = Color.Empty;
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
		public Color PixelColor
		{
			get { return _pixelColor; }
			set
			{ 
				if(value.ToArgb() != _pixelColor.ToArgb())
				{
					_pixelColor = value;
					_isChanged = true;
				}
			}
		}

		public void Clear()
		{
			PixelColor = Color.Empty;
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