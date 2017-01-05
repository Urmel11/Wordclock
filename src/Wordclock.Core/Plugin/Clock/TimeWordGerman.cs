using System.Drawing;
using System.Collections.Generic;

namespace Wordclock.Core.Plugin
{
	/// <summary>
	/// Class provides access to the German words for a given time
	/// </summary>
	public class TimeWordGerman : ITimeWordProvider
	{
		public IEnumerable<Point> GetMinute(int minute)
		{
			List<Point> result = new List<Point>();

			switch(minute)
			{
			case 0:
				break;
			case 5:
				//FÜNF NACH
				result.AddRange(GetMinute5());
				result.AddRange(GetPast());
				break;
			case 10:
				//ZEHN NACH
				result.AddRange(GetMinute10());
				result.AddRange(GetPast());
				break;
			case 15:
				//VIERTEL NACH
				result.AddRange(GetMinute15());
				result.AddRange(GetPast());
				break;
			case 20:
				//ZWANZIG NACH
				result.Add(new Point(4,1));
				result.Add(new Point(5,1));
				result.Add(new Point(6,1));
				result.Add(new Point(7,1));
				result.Add(new Point(8,1));
				result.Add(new Point(9,1));
				result.Add(new Point(10,1));
				result.AddRange(GetPast());

				break;
			case 25:
				//FÜNF VOR HALB
				result.AddRange(GetMinute5());
				result.AddRange(GetTo());
				result.AddRange(GetMinute(30));
				break;
			case 30:
				//HALB
				result.Add(new Point(0,4));
				result.Add(new Point(1,4));
				result.Add(new Point(2,4));
				result.Add(new Point(3,4));
				break;
			case 35:
				//FÜNF NACH HALB
				result.AddRange(GetMinute5());
				result.AddRange(GetPast());
				result.AddRange(GetMinute(30));
				break;
			case 40:
				//ZEHN NACH HALB
				result.AddRange(GetMinute10());
				result.AddRange(GetPast());
				result.AddRange(GetMinute(30));
				break;
			case 45:
				//DREIVIERTEL
				result.Add(new Point(0,2));
				result.Add(new Point(1,2));
				result.Add(new Point(2,2));
				result.Add(new Point(3,2));
				result.AddRange(GetMinute15());
				break;
			case 50:
				//ZEHN VOR
				result.AddRange(GetMinute10());
				result.AddRange(GetTo());
				break;
			case 55:
				//FÜNF VOR
				result.AddRange(GetMinute5());
				result.AddRange(GetTo());
				break;
			}

			return result;
		}

		public IEnumerable<Point> GetHour(int hour, int minute)
		{
			List<Point> result = new List<Point>();

			switch(hour)
			{
			case 1:
				result.Add(new Point(2,5));
				result.Add(new Point(3,5));
				result.Add(new Point(4,5));

				if (minute >= 5)
				{
					result.Add(new Point(5, 5));
				}
				break;
			case 2:
				result.Add(new Point(0,5));
				result.Add(new Point(1,5));
				result.Add(new Point(2,5));
				result.Add(new Point(3,5));
				break;
			case 3:
				result.Add(new Point(1,6));
				result.Add(new Point(2,6));
				result.Add(new Point(3,6));
				result.Add(new Point(4,6));
				break;
			case 4:
				result.Add(new Point(7,7));
				result.Add(new Point(8,7));
				result.Add(new Point(9,7));
				result.Add(new Point(10,7));
				break;
			case 5:
				result.Add(new Point(7,6));
				result.Add(new Point(8,6));
				result.Add(new Point(9,6));
				result.Add(new Point(10,6));
				break;
			case 6:
				result.Add(new Point(1,9));
				result.Add(new Point(2,9));
				result.Add(new Point(3,9));
				result.Add(new Point(4,9));
				result.Add(new Point(5,9));
				break;
			case 7:
				result.Add(new Point(5,5));
				result.Add(new Point(6,5));
				result.Add(new Point(7,5));
				result.Add(new Point(8,5));
				result.Add(new Point(9,5));
				result.Add(new Point(10,5));
				break;
			case 8:
				result.Add(new Point(1,8));
				result.Add(new Point(2,8));
				result.Add(new Point(3,8));
				result.Add(new Point(4,8));
				break;
			case 9:
				result.Add(new Point(3,7));
				result.Add(new Point(4,7));
				result.Add(new Point(5,7));
				result.Add(new Point(6,7));
				break;
			case 10:
				result.Add(new Point(5,8));
				result.Add(new Point(6,8));
				result.Add(new Point(7,8));
				result.Add(new Point(8,8));
				break;
			case 11:
				result.Add(new Point(0,7));
				result.Add(new Point(1,7));
				result.Add(new Point(2,7));
				break;
			case 0:
			case 12:
				result.Add(new Point(5,4));
				result.Add(new Point(6,4));
				result.Add(new Point(7,4));
				result.Add(new Point(8,4));
				result.Add(new Point(9,4));
				break;
			}

			return result;
		}

		public IEnumerable<Point> GetPrefix()
		{
			List<Point> result = new List<Point>();

			result.Add(new Point(8,9));
			result.Add(new Point(9,9));
			result.Add(new Point(10,9));

			return result;
		}

		public IEnumerable<Point> GetSuffix()
		{
			List<Point> result = new List<Point>();

			//ES
			result.Add(new Point(0,0));
			result.Add(new Point(1,0));

			//IST
			result.Add(new Point(3,0));
			result.Add(new Point(4,0));
			result.Add(new Point(5,0));

			return result;
		}

		public IEnumerable<Point> GetPast()
		{
			List<Point> result = new List<Point>();

			//NACH
			result.Add(new Point(2,3));
			result.Add(new Point(3,3));
			result.Add(new Point(4,3));
			result.Add(new Point(5,3));

			return result;
		}

		public IEnumerable<Point> GetTo()
		{
			List<Point> result = new List<Point>();

			//VOR
			result.Add(new Point(6,3));
			result.Add(new Point(7,3));
			result.Add(new Point(8,3));

			return result;
		}

		private IEnumerable<Point> GetMinute5()
		{
			List<Point> result = new List<Point>();

			result.Add(new Point(7,0));
			result.Add(new Point(8,0));
			result.Add(new Point(9,0));
			result.Add(new Point(10,0));
		
			return result;
		}

		private IEnumerable<Point> GetMinute10()
		{
			List<Point> result = new List<Point>();
				
			result.Add(new Point(0,1));
			result.Add(new Point(1,1));
			result.Add(new Point(2,1));
			result.Add(new Point(3,1));

			return result;
		}

		private IEnumerable<Point> GetMinute15()
		{
			List<Point> result = new List<Point>();

			result.Add(new Point(4,2));
			result.Add(new Point(5,2));
			result.Add(new Point(6,2));
			result.Add(new Point(7,2));
			result.Add(new Point(8,2));
			result.Add(new Point(9,2));
			result.Add(new Point(10,2));

			return result;
		}
	}
}

