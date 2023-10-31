using System.Collections.Generic;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class represents the ambilight
	/// </summary>
	public class AmbilightLayout
	{
		public AmbilightLayout(PixelStrip left, PixelStrip right)
		{
			LeftAmbilight	= left;
			RightAmbilight	= right;		
		}
		
		public IEnumerable<Pixel> GetChangedPixels()
		{
			var result = new List<Pixel>();

			result.AddRange(LeftAmbilight.GetChangedPixels());
			result.AddRange(RightAmbilight.GetChangedPixels());

			return result;
		}
		
		public void AcceptChanges()
		{
			LeftAmbilight.AcceptChanges();
			RightAmbilight.AcceptChanges();
		}

		public PixelStrip LeftAmbilight { get; }

		public PixelStrip RightAmbilight { get; }

		public bool IsChanged => LeftAmbilight.IsChanged || RightAmbilight.IsChanged;
	}
}
