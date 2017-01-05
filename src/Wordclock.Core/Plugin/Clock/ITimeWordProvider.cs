using System.Collections.Generic;
using System.Drawing;

namespace Wordclock.Core.Plugin
{
	/// <summary>
	/// Interface which provides convertes the time in words
	/// </summary>
	public interface ITimeWordProvider
	{
		IEnumerable<Point> GetHour(int hour, int minute);
		IEnumerable<Point> GetMinute(int minute);
		IEnumerable<Point> GetPrefix();
		IEnumerable<Point> GetSuffix();
		IEnumerable<Point> GetPast();
		IEnumerable<Point> GetTo();
	}
}

