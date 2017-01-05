using System.Collections.Generic;
using System.ComponentModel;

namespace Wordclock.Base.Layout
{
	/// <summary>
	/// Class which represents the layout of the pixels
	/// </summary>
	public class PluginLayout : IChangeTracking
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
		public List<Pixel> GetChangedPixels()
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
		
		public Matrix Matrix { get; private set; }

		public PixelStrip Minutes { get; private set; }

		/// <summary>
		/// Gets a valud which is indicating if the layout changed
		/// </summary>
		public bool IsChanged
		{
			get
			{
				return Matrix.IsChanged ||
						Minutes.IsChanged;
			}
		}
	}
}
