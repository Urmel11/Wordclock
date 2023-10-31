using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Wordclock.Core.Layout
{
	/// <summary>
	/// Class represents the matrix
	/// </summary>
	public class Matrix
	{	
		private readonly List<Pixel> _pixels;

		/// <summary>
		/// Initializes the matrix
		/// </summary>
		/// <param name="width">Width</param>
		/// <param name="height">Height</param>
		public Matrix(int width, int height)
		{
			Width	= width;
			Height	= height;

			_pixels = new List<Pixel>();
			InitializePixels();
		}

		/// <summary>
		/// Returns the specific pixel on the given position
		/// </summary>
		/// <param name="x">X-position</param>
		/// <param name="y">Y-Position</param>
		/// <returns></returns>
		public Pixel GetPixel(int x, int y)
		{
			var pixelId = CalculatePixelID(x, y);
			return _pixels.First(p => p.PixelID == pixelId);
		}

		/// <summary>
		/// Change the color of the pixel on the given position
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="newColor"></param>
		private void SetPixelColor(int x, int y, Color newColor)
		{
			if ((x >= 0 && x < Width) && (y >= 0 && y < Height))
				GetPixel(x, y).PixelColor = newColor;
		}

		/// <summary>
		/// Change the color of the given points
		/// </summary>
		/// <param name="points"></param>
		/// <param name="color"></param>
		public void SetPixelColor(IEnumerable<Point> points, Color color)
		{
			foreach (var p in points)
				SetPixelColor(p.X, p.Y, color);
		}

		/// <summary>
		/// Accept the changes
		/// </summary>
		public void AcceptChanges() => _pixels.ForEach(x => x.AcceptChanges());
		
		/// <summary>
		/// Reset the color of all pixels
		/// </summary>
		public void Clear() => _pixels.ForEach(x => x.Clear());

		/// <summary>
		/// Returns the changed pixels
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Pixel> GetChangedPixels() => _pixels.Where(x => x.IsChanged);
			
		/// <summary>
		/// Initializes the pixels in the matrix
		/// </summary>
		private void InitializePixels()
		{			
			for(int i=0; i<= Height -1; i++)
			{
				for (int k = 0; k <= Width - 1; k++)
					_pixels.Add(new Pixel(CalculatePixelID(k, i)));
			}
		}

		/// <summary>
		/// Calculates the ID of the pixel in the matrix
		/// </summary>
		/// <returns>The LE did.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		private int CalculatePixelID(int x, int y)
		{
			if(y % 2 == 0)
				return (y * Width) + x;
		
			return (y * Width) + (Width - x - 1);
		}

		/// <summary>
		/// Returns the height of the matrix
		/// </summary>
		public int Height { get; }

		/// <summary>
		/// Returns the width of the matrix
		/// </summary>
		public int Width { get; }

		/// <summary>
		/// Returns a value which indicates if the matrix has changes
		/// </summary>
		public bool IsChanged => _pixels.Any(x => x.IsChanged);
	}
}
