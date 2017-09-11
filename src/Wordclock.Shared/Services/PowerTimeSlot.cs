using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				return StarTime.TotalSeconds > 0 || EndTime.TotalSeconds > 0;
			}
		}

		/// <summary>
		/// Returns a value which indcates if the given time span is between StarTime and EndTime
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public bool IsTimeInRange(TimeSpan time)
		{
			return time.TotalSeconds >= StarTime.TotalSeconds && 
					time.TotalSeconds <= EndTime.TotalSeconds;
		}
	}
}
