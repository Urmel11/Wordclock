using Wordclock.Core.Layout;
using Wordclock.Core.Plugin;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Ui.Win
{
	public partial class Demo : Form
	{
		private const int PIXEL_SIZE = 50;
		private readonly PluginManager _pluginManager;
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

		public Demo(ILayoutFactory layoutFactory, IRenderEngine renderEngine, PluginManager pluginManager)
		{
			_pluginManager = pluginManager ?? throw new ArgumentNullException(nameof(pluginManager));

			InitializeComponent();

			InitializeLayout(layoutFactory, (UiRenderEngine)renderEngine);
			EnablePluginButtons();
		}

		private void InitializeLayout(ILayoutFactory layoutFactory, UiRenderEngine renderEngine)
		{
			var layout = layoutFactory.CreateLayout();

			var pixels = new List<UiPixel>();

			pixels.AddRange(CreateMatrixPixels(layout.Matrix));
			pixels.AddRange(CreateMinutePixels(layout.Minutes, layout.Matrix.Height));
			pixels.AddRange(CreatAmbilightPixels(layout.Ambilight, layout.Matrix.Width));

			pixels.ForEach(x => Controls.Add(x));

			renderEngine.SetPixel(pixels);
		}

		private void EnablePluginButtons()
		{
			var activePlugin = _pluginManager.GetActivePlugin();
			if (activePlugin is null)
				return;

			btnClock.Enabled = !activePlugin.GetType().Equals(typeof(Clock));
			btnKnightRider.Enabled = !activePlugin.GetType().Equals(typeof(KnightRider));
		}

		private void ChangePlugin<T>() where T : BasePlugin
		{
			_pluginManager.ChangeActivePlugin<T>();
			EnablePluginButtons();
		}

		private IEnumerable<UiPixel> CreateMatrixPixels(Matrix matrix)
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

		private IEnumerable<UiPixel> CreateMinutePixels(PixelStrip minutes, int matrixHeight)
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

		private IEnumerable<UiPixel> CreatAmbilightPixels(Ambilight ambilight, int matrixWidth)
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

		private void btnClock_Click(object sender, EventArgs e)
		{
			ChangePlugin<Clock>();
		}

		private void btnKnightRider_Click(object sender, EventArgs e)
		{
			ChangePlugin<KnightRider>();
		}
	}
}