using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Wordclock.Base.Layout
{
	/// <summary>
	/// Class represents the matrix
	/// </summary>
	public class Matrix : IChangeTracking
	{	
		private List<Pixel> _pixels;

		/// <summary>
		/// Initializes the matrix
		/// </summary>
		/// <param name="width">Width</param>
		/// <param name="height">Height</param>
		public Matrix(int width, int height)
		{
			Width	= width;
			Height	= height;

			//Creates the pixel objects
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
			int pixelID = CalculatePixelID(x, y);
			return _pixels.Where(p => p.PixelID == pixelID).First();
		}

		/// <summary>
		/// Change the color of the pixel on the given position
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="newColor"></param>
		public void SetPixelColor(int x, int y, ColorSurrogate newColor)
		{
			if ((x >= 0 && x < Width) && (y >= 0 && y < Height))
			{
				GetPixel(x, y).PixelColor = newColor;
			}
		}

		/// <summary>
		/// Change the color of the given points
		/// </summary>
		/// <param name="points"></param>
		/// <param name="color"></param>
		public void SetPixelColor(IEnumerable<PointSurrogate> points, ColorSurrogate color)
		{
			foreach (var p in points)
			{
				SetPixelColor(p.X, p.Y, color);
			}
		}
		
		/// <summary>
		/// Accept the changes
		/// </summary>
		public void AcceptChanges()
		{
			foreach(IChangeTracking p in _pixels)
			{
				p.AcceptChanges();
			}
		}

		/// <summary>
		/// Reset the color of all pixels
		/// </summary>
		public void Clear()
		{
			foreach (var pixel in _pixels)
			{
				pixel.Clear();
			}
		}

		/// <summary>
		/// Returns the changed pixels
		/// </summary>
		/// <returns></returns>
		public List<Pixel> GetChangedPixels()
		{
			return _pixels.Where(x => x.IsChanged).ToList();
		}
		
		/// <summary>
		/// Initializes the pixels in the matrix
		/// </summary>
		private void InitializePixels()
		{
			_pixels = new List<Pixel>();
			
			for(int i=0; i<= Height -1; i++)
			{
				for (int k = 0; k <= Width - 1; k++)
				{
					_pixels.Add(new Pixel(CalculatePixelID(k, i)));
				}
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
			int result;
			//Left upper corner is (0/0)
			if (x % 2 == 0)
			{
				result = (x * Height) + y;
			}
			else
			{
				result = (x * Height) + (Height - y - 1);
			}
			return result;
		}

		/// <summary>
		/// Returns the height of the matrix
		/// </summary>
		public int Height { get; private set; }


		/// <summary>
		/// Returns the width of the matrix
		/// </summary>
		public int Width { get; private set; }


		/// <summary>
		/// Returns a value which indicates if the matrix has changes
		/// </summary>
		public bool IsChanged
		{
			get
			{
				return _pixels.Where(x => x.IsChanged).Any();
			}
		}
	}
}
