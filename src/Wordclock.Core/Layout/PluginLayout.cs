using System.Collections.Generic;
using System.Linq;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class which represents the layout of the pixels
	/// </summary>
	public class PluginLayout
	{
		public PluginLayout(Matrix matrix, PixelStrip minutes, Ambilight ambilight)
		{
			Minutes = minutes;
			Matrix = matrix;
			Ambilight = ambilight;
		}
		
		/// <summary>
		/// Accpet the changes
		/// </summary>
		public void AcceptChanges()
		{
			Matrix.AcceptChanges();
			Minutes.AcceptChanges();
			Ambilight.AcceptChanges();
		}
		
		/// <summary>
		/// Returns the changed pixels of the layout
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Pixel> GetChangedPixels()
		{
			return Matrix.GetChangedPixels()
				.Concat(Minutes.GetChangedPixels())
				.Concat(Ambilight.GetChangedPixels());
		}
		
		/// <summary>
		/// Clears the pixels
		/// </summary>
		public void Clear()
		{
			Matrix.Clear();
			Minutes.Clear();
			Ambilight.Clear();
		}
		
		public Matrix Matrix { get; }

		public PixelStrip Minutes { get; }

		public Ambilight Ambilight { get; }

		/// <summary>
		/// Gets a valud which is indicating if the layout changed
		/// </summary>
		public bool IsChanged => Matrix.IsChanged || Minutes.IsChanged || Ambilight.IsChanged;
	}
}
