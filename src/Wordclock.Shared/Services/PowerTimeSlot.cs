using System;
using System.Xml.Serialization;

namespace Wordclock.Shared.Services
{
	public class PowerTimeSlot
	{
		/// <summary>
		/// Gets or sets a value which defines the weekday of the timeslot
		/// </summary>
		public DayOfWeek DayOfWeek { get; set; }

		/// <summary>
		/// Gets or sets the start time
		/// </summary>
		[XmlIgnore]
		public TimeSpan StarTime { get; set; }

		/// <summary>
		/// Gets or sets the end time
		/// </summary>
		[XmlIgnore]
		public TimeSpan EndTime { get; set; }

		public double StartTimeTotalSeconds
		{
			get
			{
				return StarTime.TotalSeconds;
			}
			set
			{
				StarTime = TimeSpan.FromSeconds(value);
			}
		}

		public double EndTimeTotalSeconds
		{
			get
			{
				return EndTime.TotalSeconds;
			}
			set
			{
				EndTime = TimeSpan.FromSeconds(value);
			}
		}

		/// <summary>
		/// Returns a value which indicates if either StartTime or EndTime is set
		/// </summary>
		public bool HasValue
		{
			get
			{
				return StartTimeTotalSeconds > 0 || EndTimeTotalSeconds > 0;
			}
		}

		/// <summary>
		/// Returns a value which indcates if the date is in the time slot
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public bool IsTimeInTimeSlot(DateTime time)
		{
			if(DayOfWeek == time.DayOfWeek)
			{
				return time.TimeOfDay.TotalSeconds >= StartTimeTotalSeconds &&
					time.TimeOfDay.TotalSeconds <= EndTimeTotalSeconds;
			}

			return false;
		}

	}
}
