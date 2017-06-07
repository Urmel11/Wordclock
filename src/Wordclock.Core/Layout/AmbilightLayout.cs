using System.ComponentModel;
using System.Collections.Generic;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class represents the ambilight
	/// </summary>
	public class AmbilightLayout : IChangeTracking
	{
		public AmbilightLayout(PixelStrip left, PixelStrip right)
		{
			LeftAmbilight	= left;
			RightAmbilight	= right;		
		}
		
		public List<Pixel> GetChangedPixels()
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

		public PixelStrip LeftAmbilight { get; private set; }

		public PixelStrip RightAmbilight { get; private set; }

		public bool IsChanged
		{
			get
			{
				return LeftAmbilight.IsChanged || 
						RightAmbilight.IsChanged;
			}
		}
	}
}
