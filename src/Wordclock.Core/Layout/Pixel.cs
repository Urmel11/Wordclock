using System.Drawing;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class which represents one pixel
	/// </summary>
	public class Pixel
	{
		private Color _pixelColor;

		public Pixel(int pixelID)
		{
			Clear();
			PixelID = pixelID;
			IsChanged = true;
		}
		/// <summary>
		/// ID of the pixel 
		/// </summary>
		public int PixelID { get; }
		
		/// <summary>
		/// Gets or sets the color
		/// </summary>
		public Color PixelColor
		{
			get => _pixelColor;
			set
			{ 
				if(!value.Equals(_pixelColor))
				{
					_pixelColor = value;
					IsChanged = true;
				}
			}
		}

		public void Clear() => PixelColor = Color.Empty;
		
		/// <summary>
		/// Indicates if the object changed
		/// </summary>
		public bool IsChanged { get; private set; }

		/// <summary>
		/// Accept all the changes
		/// </summary>
		public void AcceptChanges() => 	IsChanged = false;
	}
}
