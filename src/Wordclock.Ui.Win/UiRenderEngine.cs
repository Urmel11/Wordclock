using Wordclock.Core.Layout;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Ui.Win
{
	public class UiRenderEngine : IRenderEngine
	{
		private List<UiPixel>? _pixels;

		public void SetPixel(List<UiPixel> pixels)
		{
			_pixels = pixels;
		}

		public void Render(IEnumerable<Pixel> pixelsToRender)
		{
			if (_pixels is null)
				return;

            foreach (var pixel in pixelsToRender)
            {
				var uiPixel = _pixels.First(x => x.PixelId == pixel.PixelId);

				if (pixel.PixelColor.Equals(Color.Empty))
					uiPixel.ForeColor = Color.Gray;
				else
					uiPixel.ForeColor = pixel.PixelColor;
            }
        }
	}
}
