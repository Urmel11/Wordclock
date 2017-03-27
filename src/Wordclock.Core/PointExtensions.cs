using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;

namespace Wordclock.Core
{
	public static class PointExtensions
	{
		public static List<PointSurrogate> ToPointSurrogate(this IEnumerable<Point> points)
		{
			var result = new List<PointSurrogate>();

			foreach(var p in points)
			{
				result.Add(new PointSurrogate() { X = p.X, Y = p.Y });
			}

			return result;
		}
	}
}
