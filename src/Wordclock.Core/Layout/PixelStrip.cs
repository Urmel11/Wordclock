using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class represents a strip of pixels
	/// </summary>
	public class PixelStrip
	{
		private readonly List<Pixel> _strip;

		/// <summary>
		/// Initializes the object
		/// </summary>
		public PixelStrip(int count, int offset)
		{
			_strip = new List<Pixel>();

			for (int i = 0; i < count; i++)
				_strip.Add(new Pixel(i + offset));
		}

		/// <summary>
		/// Sets the color on all pixels in the strip
		/// </summary>
		/// <param name="newColor">Color to set</param>
		public void ChangeColor(Color newColor) => _strip.ForEach(x=> x.PixelColor = newColor);

		/// <summary>
		/// Accept the changes
		/// </summary>
		public void AcceptChanges() => _strip.ForEach(x => x.AcceptChanges());

		/// <summary>
		/// Reset the color of all pixels
		/// </summary>
		public void Clear() => _strip.ForEach(pixel => pixel.Clear());
		
		/// <summary>
		/// Returns the changed pixels
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Pixel> GetChangedPixels() => _strip.Where(x => x.IsChanged);
		
		/// <summary>
		/// Returns a value which is indicating if the strip has changed
		/// </summary>
		public bool IsChanged => _strip.Any(x => x.IsChanged);
		
		/// <summary>
		/// Returns the current strip
		/// </summary>
		/// <returns></returns>
		public IReadOnlyList<Pixel> Strip =>_strip.AsReadOnly();
	}
}
