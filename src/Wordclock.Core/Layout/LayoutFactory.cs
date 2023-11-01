namespace Wordclock.Core.Layout
{
	public class LayoutFactory : ILayoutFactory
	{
		public PluginLayout CreateLayout()
		{
			var minuteStrip = new PixelStrip(4, 110);
			var matrix = new Matrix(11, 10);
			var leftAmbilight = new PixelStrip(13, 114);
			var rightAmbilight = new PixelStrip(13, 127);

			return new PluginLayout(matrix, minuteStrip, new Ambilight(leftAmbilight, rightAmbilight));
		}
	}
}
