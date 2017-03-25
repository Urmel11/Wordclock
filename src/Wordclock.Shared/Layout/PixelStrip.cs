using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Wordclock.Base.Layout
{
	/// <summary>
	/// Class represents a strip of pixels
	/// </summary>
	public class PixelStrip : IChangeTracking
	{
		private List<Pixel> _strip;

		/// <summary>
		/// Initializes the object
		/// </summary>
		public PixelStrip(int count, int offset)
		{
			_strip = new List<Pixel>();
			AddPixels(count, offset);
		}

		/// <summary>
		/// Sets the color on all pixels in the strip
		/// </summary>
		/// <param name="newColor">Color to set</param>
		public void ChangeColor(ColorSurrogate newColor)
		{
			foreach(var pixel in _strip)
			{
				pixel.PixelColor = newColor;
			}
		}
		
		public void AddPixel(int pixelID)
		{
			_strip.Add(new Pixel(pixelID));
		}		

		public void AddPixels(int count, int offset)
		{
			for (int i = 0; i < count; i++)
			{
				AddPixel(i + offset);
			}
		}

		/// <summary>
		/// Accept the changes
		/// </summary>
		public void AcceptChanges()
		{
			foreach (IChangeTracking pixel in _strip)
			{
				pixel.AcceptChanges();
			}
		}

		/// <summary>
		/// Reset the color of all pixels
		/// </summary>
		public void Clear()
		{
			foreach (var pixel in _strip)
			{
				pixel.Clear();
			}
		}

		/// <summary>
		/// Returns the changed pixels
		/// </summary>
		/// <returns></returns>
		public List<Pixel> GetChangedPixels()
		{
			return _strip.Where(x => x.IsChanged).ToList();
		}
		
		/// <summary>
		/// Returns a value which is indicating if the strip has changed
		/// </summary>
		public bool IsChanged
		{
			get
			{
				return _strip.Where(x => x.IsChanged).Any();
			}
		}

		/// <summary>
		/// Returns the current strip
		/// </summary>
		/// <returns></returns>
		public List<Pixel> Strip
		{
			get
			{
				return _strip;
			}
		}

	}
}
