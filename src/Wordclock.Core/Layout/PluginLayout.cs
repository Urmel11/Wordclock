using System.Collections.Generic;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class which represents the layout of the pixels
	/// </summary>
	public class PluginLayout
	{
		public PluginLayout(Matrix matrix, PixelStrip minutes)
		{
			Minutes = minutes;
			Matrix = matrix;
		}
		
		/// <summary>
		/// Accpet the changes
		/// </summary>
		public void AcceptChanges()
		{
			Matrix.AcceptChanges();
			Minutes.AcceptChanges();
		}
		
		/// <summary>
		/// Returns the changed pixels of the layout
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Pixel> GetChangedPixels()
		{
			var result = new List<Pixel>();
			
			result.AddRange(Minutes.GetChangedPixels());
			result.AddRange(Matrix.GetChangedPixels());

			return result;
		}
		
		/// <summary>
		/// Clears the pixels
		/// </summary>
		public void Clear()
		{
			Matrix.Clear();
			Minutes.Clear();
		}
		
		public Matrix Matrix { get; }

		public PixelStrip Minutes { get; }

		/// <summary>
		/// Gets a valud which is indicating if the layout changed
		/// </summary>
		public bool IsChanged => Matrix.IsChanged || Minutes.IsChanged;
	}
}
