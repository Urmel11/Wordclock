using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;
using System.Drawing;

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
			IsTrackingAllowed = true;
			_activePixels = new List<Pixel>();
		}

		public void Track(IEnumerable<Pixel> pixels)
		{
			if(IsTrackingAllowed)
			{
				var ids = pixels.Select(x => x.PixelID);

				_activePixels.RemoveAll(x => ids.Contains(x.PixelID));
				_activePixels.AddRange(pixels.Where(x => x.PixelColor != Color.Empty));
			}
		}

		public List<Pixel> GetActivePixels()
		{
			return _activePixels.ToList();
		}

		/// <summary>
		/// Indicates if tracking is allowed or not
		/// </summary>
		public bool IsTrackingAllowed { get; set; }
	}
}
