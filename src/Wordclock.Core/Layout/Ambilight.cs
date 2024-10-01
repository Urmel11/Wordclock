using System.Collections.Generic;
using System.Linq;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class represents the ambilight
	/// </summary>
	public class Ambilight
	{
		public Ambilight(PixelStrip left, PixelStrip right)
		{
			Left = left;
			Right = right;
		}

		public IEnumerable<Pixel> GetChangedPixels()
		{
			return Left.GetChangedPixels().Concat(Right.GetChangedPixels());
		}

		public void AcceptChanges()
		{
			Left.AcceptChanges();
			Right.AcceptChanges();
		}

		public PixelStrip Left { get; }

		public PixelStrip Right { get; }

		public void Clear()
		{
			Left.Clear();
			Right.Clear();
		}

		public bool IsChanged => Left.IsChanged || Right.IsChanged;
	}
}
