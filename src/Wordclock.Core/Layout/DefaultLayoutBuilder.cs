using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Base.Layout
{
	public class DefaultLayoutBuilder : ILayoutBuilder
	{
		public AmbilightLayout CreateAmbilight()
		{
			var leftAmbilight = new PixelStrip(13, 114);
			var rightAmbilight = new PixelStrip(13, 127);

			return new AmbilightLayout(leftAmbilight, rightAmbilight);
		}

		public PluginLayout CreateLayout()
		{
			var minuteStrip = new PixelStrip(4, 110);
			var matrix = new Matrix(11, 10);

			return new PluginLayout(matrix, minuteStrip);
		}
	}
}
