using Wordclock.Shared;

namespace Wordclock.Core
{
	public static class ColorExtensions
	{
		/// <summary>
		/// Converts a ColorSurrogate into a color object
		/// </summary>
		/// <param name="surrogate"></param>
		/// <returns></returns>
		public static System.Drawing.Color ToColor(this ColorSurrogate surrogate)
		{
			return System.Drawing.Color.FromArgb(surrogate.R, surrogate.G, surrogate.B);
		}

		/// <summary>
		/// Converts a Color to a ColorSurrogate structure
		/// </summary>
		/// <param name="col"></param>
		/// <returns></returns>
		public static ColorSurrogate ToColorSurrogate(this System.Drawing.Color col)
		{
			return new ColorSurrogate()
			{
				R = col.R,
				G = col.G,
				B = col.B
			};
		}
	}
}
