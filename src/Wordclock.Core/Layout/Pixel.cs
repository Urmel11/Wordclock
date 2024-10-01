using System.Drawing;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class which represents one pixel
	/// </summary>
	public class Pixel
	{
		private Color _pixelColor;

		public Pixel(int pixelId)
		{
			Clear();
			PixelId = pixelId;
			IsChanged = true;
		}
		/// <summary>
		/// Id of the pixel 
		/// </summary>
		public int PixelId { get; }

		/// <summary>
		/// Gets or sets the color
		/// </summary>
		public Color PixelColor
		{
			get => _pixelColor;
			set
			{
				if (!value.Equals(_pixelColor))
				{
					_pixelColor = value;
					IsChanged = true;
				}
			}
		}

		public void Clear()
		{
			_pixelColor = Color.Empty;
			IsChanged = true;
		}

		/// <summary>
		/// Indicates if the object changed
		/// </summary>
		public bool IsChanged { get; private set; }

		/// <summary>
		/// Accept all the changes
		/// </summary>
		public void AcceptChanges() => IsChanged = false;
	}
}
