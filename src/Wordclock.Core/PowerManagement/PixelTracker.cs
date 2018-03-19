using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Wordclock.Core.Layout;
using Wordclock.Shared;

namespace Wordclock.Core.PowerManagement
{
	/// <summary>
	/// Class provides functionality to track the active pixels
	/// of the current layout
	/// </summary>
	class PixelTracker
	{
		private List<Pixel> _activePixels;

		public PixelTracker()
		{
			_activePixels = new List<Pixel>();
		}

		public void Track(IEnumerable<Pixel> pixels)
		{
			var ids = pixels.Select(x => x.PixelID);

			_activePixels.RemoveAll(x => ids.Contains(x.PixelID));
			_activePixels.AddRange(pixels.Where(x => !x.PixelColor.Equals(Color.Empty)));
		}

		public List<Pixel> GetActivePixels()
		{
			return _activePixels.ToList();
		}
		
	}
}
