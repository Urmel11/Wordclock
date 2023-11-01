using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Wordclock.Core.Layout;

namespace Wordclock.Core.Plugin
{
	public class KnightRider : BasePlugin
	{
		public KnightRider(ILayoutFactory layoutFactor) : base(layoutFactor) { }

		protected override async Task Execute(CancellationToken cancellationToken)
		{
			var downDirection = false;
			var beamLength = 15;
			var index = 0;

			var pixels = new List<Pixel>();
			for (int i = 0; i < Layout.Matrix.Height; i++)
			{
				for (int k = 0; k < Layout.Matrix.Width; k++)
				{
					pixels.Add(Layout.Matrix.GetPixel(k, i));
				}
			}

			pixels.AddRange(Layout.Minutes);
			pixels.AddRange(Layout.Ambilight.Right);
			pixels.AddRange(Layout.Ambilight.Left);

			while (!cancellationToken.IsCancellationRequested)
			{
				for (int i = 0; i < pixels.Count; i++)
				{
					pixels[i].PixelColor = Color.FromArgb(0, 0, 0, 0);
				}

				if (downDirection)
				{
					for (int i = 0; i <= beamLength; i++)
					{
						if (index + i < pixels.Count && index + i >= 0)
						{
							var redValue = (beamLength - i) * (255 / (beamLength + 1));
							pixels[index + i].PixelColor = Color.FromArgb(0, redValue, 0, 0);
						}
					}

					index--;
					if (index < -beamLength)
					{
						downDirection = false;
						index = 0;
					}
				}
				else
				{
					for (int i = beamLength - 1; i >= 0; i--)
					{
						if (index - i >= 0 && index - i < pixels.Count)
						{
							var redValue = (beamLength - i) * (255 / (beamLength + 1));
							pixels[index - i].PixelColor = Color.FromArgb(0, redValue, 0, 0);
						}
					}

					index++;
					if (index - beamLength >= pixels.Count)
					{
						downDirection = true;
						index = pixels.Count - 1;
					}
				}

				Render();
				await Task.Delay(10, cancellationToken);
			}
		}
	}
}
