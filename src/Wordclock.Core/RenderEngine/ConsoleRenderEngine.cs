using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Wordclock.Core.Layout;

namespace Wordclock.Core.RenderEngine
{
	/// <summary>
	/// Provides a render engine which draws the pixels on the console
	/// </summary>
	public class ConsoleRenderEngine : IRenderEngine
	{
		private string[,] _matrixCover = new string[,]
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

		private ILayoutBuilder _layoutBuilder;
		private List<ConsolePixel> _consolePixels = new List<ConsolePixel>();

		public ConsoleRenderEngine(ILayoutBuilder builder)
		{
			_layoutBuilder = builder;
			DrawInitialScreen();
		}

		void IRenderEngine.Render(IEnumerable<Pixel> pixelsToRender)
		{
			List<Pixel> changedPixels = pixelsToRender.ToList();

			for(int i=0; i<= changedPixels.Count -1; i++)
			{
				ConsolePixel? p = _consolePixels.Where(x => x.PixelID == changedPixels[i].PixelID).FirstOrDefault();

				if(p == null)
				{
					break;
				}

				Console.ForegroundColor = ConsoleColor.Yellow;

				if(changedPixels[i].PixelColor.Equals(Color.Empty))
				{
					Console.ResetColor();
				}

				Console.SetCursorPosition(p.ConsoleLeft, p.ConsoleTop);
				Console.Write(p.Character);
			}

		}
		
		private void DrawInitialScreen()
		{
			AmbilightLayout ambilight = _layoutBuilder.CreateAmbilight();
			PluginLayout layout = _layoutBuilder.CreateLayout();

			Console.WriteLine();

			int originalTop = Console.CursorTop;
            for (int i=0; i<= ambilight.LeftAmbilight.Strip.Count -1; i++)
			{
				_consolePixels.Add(new ConsolePixel { PixelID = ambilight.LeftAmbilight.Strip[i].PixelID, ConsoleLeft = Console.CursorLeft, ConsoleTop = Console.CursorTop, Character = "O" });
				Console.WriteLine("O\t\t");
			}

			Console.SetCursorPosition(3, originalTop);
			for(int i=0;i<=layout.Matrix.Height -1; i++)
			{
				for(int k=0; k<= layout.Matrix.Width -1; k++)
				{
					_consolePixels.Add(new ConsolePixel { PixelID = layout.Matrix.GetPixel(k, i).PixelID, ConsoleLeft = Console.CursorLeft, ConsoleTop = Console.CursorTop, Character = _matrixCover[i, k] });
					Console.Write(_matrixCover[i, k] + " ");
				}
				Console.WriteLine();
				Console.SetCursorPosition(3, i + 1 + originalTop);
			}

			Console.SetCursorPosition(3 + layout.Matrix.Width * 2, originalTop);
			for (int i = 0; i <= ambilight.RightAmbilight.Strip.Count - 1; i++)
			{
				_consolePixels.Add(new ConsolePixel { PixelID = ambilight.RightAmbilight.Strip[i].PixelID, ConsoleLeft = Console.CursorLeft, ConsoleTop = Console.CursorTop, Character="  O" });
				Console.Write("  O");
				Console.CursorTop	+= 1;
				Console.CursorLeft -= 3;
			}
			Console.WriteLine();

			Console.Write("\t");

			for (int i = 0; i<= layout.Minutes.Strip.Count - 1; i++)
			{
				_consolePixels.Add(new ConsolePixel { PixelID = layout.Minutes.Strip[i].PixelID, ConsoleLeft = Console.CursorLeft, ConsoleTop = Console.CursorTop, Character="X" });
				Console.Write("X ");
			}
		}
	}

	public class ConsolePixel
	{
		public int PixelID { get; set; }
		public int ConsoleTop { get; set; }
		public int ConsoleLeft { get; set; }
		public string? Character { get; set; }
	}
}
