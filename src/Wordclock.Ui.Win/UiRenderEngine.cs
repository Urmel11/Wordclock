using Wordclock.Core.Layout;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Ui.Win
{
	public class UiRenderEngine : IRenderEngine
	{
		private const int PIXEL_SIZE = 50;

		private readonly List<UiPixel> _pixels;
		private readonly Demo _demo;
		
		private readonly string[,] _matrixCover = new string[,]
		{
			{"E", "S", "K", "I", "S", "T", "L", "F", "Ü", "N", "F"},
			{"Z", "E", "H", "N", "Z", "W", "A", "N", "Z", "I", "G"},
			{"D", "R", "E", "I", "V", "I", "E", "R", "T", "E", "L"},
			{"T", "G", "N", "A", "C", "H", "V", "O", "R", "I", "M"},
			{"H", "A", "L", "B", "Q", "Z", "W", "Ö", "L", "F", "P"},
			{"Z", "W", "E", "I", "N", "S", "I", "E", "B", "E", "N"},
			{"K", "D", "R", "E", "I", "R", "H", "F", "Ü", "N", "F"},
			{"E", "L", "F", "N", "E", "U", "N", "V", "I", "E", "R"},
			{"W", "A", "C", "H", "T", "Z", "E", "H", "N", "R", "S"},
			{"B", "S", "E", "C", "H", "S", "F", "M", "U", "H", "R"}
		};
		
		public UiRenderEngine(ILayoutFactory layoutFactory, Demo demo)
		{
			_pixels = [];
			_demo = demo;

			InitializeLayout(layoutFactory);
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

		private void InitializeLayout(ILayoutFactory layoutFactory)
		{
			var layout = layoutFactory.CreateLayout();

			_pixels.AddRange(CreateMatrixPixels(layout.Matrix));
			_pixels.AddRange(CreateMinutePixels(layout.Minutes, layout.Matrix.Height));
			_pixels.AddRange(CreatAmbilightPixels(layout.Ambilight, layout.Matrix.Width));

			_pixels.ForEach(x => _demo.Controls.Add(x));
		}

		private List<UiPixel> CreateMatrixPixels(Matrix matrix)
		{
			var result = new List<UiPixel>();
			int xOffsetCausedByAmbilight = PIXEL_SIZE + (PIXEL_SIZE / 2);

			for (int i = 0; i < matrix.Height; i++)
			{
				for (int k = 0; k < matrix.Width; k++)
				{
					var pixelId = matrix.GetPixel(k, i).PixelId;
					var character = _matrixCover[i, k];

					var uiPixel = new UiPixel(PIXEL_SIZE, character, pixelId);

					uiPixel.Location = new Point(k * PIXEL_SIZE + xOffsetCausedByAmbilight, i * PIXEL_SIZE);
					result.Add(uiPixel);
				}
			}

			return result;
		}

		private List<UiPixel> CreateMinutePixels(PixelStrip minutes, int matrixHeight)
		{
			var result = new List<UiPixel>();
			var xOffsetForMinuteAlignment = 5 * PIXEL_SIZE;

			for (int i = 0; i < minutes.Count; i++)
			{
				var pixelId = minutes[i].PixelId;
				var uiPixel = new UiPixel(PIXEL_SIZE, "O", pixelId);

				uiPixel.Location = new Point(xOffsetForMinuteAlignment + i * PIXEL_SIZE, (matrixHeight + 1) * PIXEL_SIZE);

				result.Add(uiPixel);
			}

			return result;
		}

		private List<UiPixel> CreatAmbilightPixels(Ambilight ambilight, int matrixWidth)
		{
			var result = new List<UiPixel>();

			for (int i = 0; i < ambilight.Left.Count; i++)
			{
				var pixelId = ambilight.Left[i].PixelId;
				var uiPixel = new UiPixel(PIXEL_SIZE, "O", pixelId);

				uiPixel.Location = new Point(0, i * PIXEL_SIZE);

				result.Add(uiPixel);
			}

			for (int i = 0; i < ambilight.Right.Count; i++)
			{
				var pixelId = ambilight.Right[i].PixelId;
				var uiPixel = new UiPixel(PIXEL_SIZE, "O", pixelId);

				uiPixel.Location = new Point((matrixWidth + 2) * PIXEL_SIZE, i * PIXEL_SIZE);

				result.Add(uiPixel);
			}

			return result;
		}
	}
}
