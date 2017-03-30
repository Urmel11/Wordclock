using System;
using System.Collections.Generic;
using System.Drawing;
using Wordclock.Base.Layout;

namespace Wordclock.Core.Plugin
{
	/// <summary>
	/// Plugin for showing the time 
	/// </summary>
	public class Clock : BasePlugin
	{
		private ITimeWordProvider _wordProvider;
		private System.Timers.Timer _timer;
		private Color _color;
		private bool _printSuffix;

		private int _oldMinute;

		public Clock(PluginLayout layout) : base(layout)
		{
			//Use the German layout by default
			_wordProvider = new TimeWordGerman();
			_color = Color.White;
			_printSuffix = true;

			InitializeTimer();
		}

		/// <summary>
		/// Starts the plugin
		/// </summary>
		private void InitializeTimer()
		{
			//Ensure that the timer could not started twice
			if(_timer == null)
			{
				_timer = new System.Timers.Timer();
				_timer.Interval = 5*1000;
				_timer.Elapsed += TimerElapsed;
				_timer.Enabled = true;
				_timer.Start();

				//Ensure that the minute differs the first time so that a rendering is necessary
				_oldMinute = -1;

				//The elapsed event of the timer will be fired if the interval is reached
				//To avoid delay after starting the clock, the time is set immediately
				SetTime(DateTime.Now);
			}
		}
		
		private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				//Disable the timer that the event is not called twice
				_timer.Enabled = false;
				SetTime(DateTime.Now);
			}
			finally
			{
				_timer.Enabled = true;
			}
		}

		public Color GetClockColor()
		{
			return _color;
		}

		public void SetClockColor(Color newColor)
		{
			_color = newColor;
			_oldMinute = _oldMinute - 1;
			SetTime(DateTime.Now);
		}

		/// <summary>
		/// Set the current time
		/// </summary>
		/// <param name="time"></param>
		private void SetTime(DateTime time)
		{
			IEnumerable<Point> minutes;
			IEnumerable<Point> hour;

			if (!IsUpdateRequired(time))
			{
				//Current minute and old minute are equal
				//No update is required
				return;
			}
			
			Layout.Clear();

			//The clock shows the time in a step of 5 minutes
			minutes = _wordProvider.GetMinute((time.Minute / 5) * 5);

			if (time.Minute >= 25)
			{
				hour = _wordProvider.GetHour((time.Hour % 12) + 1, time.Minute);
			}
			else
			{
				hour = _wordProvider.GetHour((time.Hour % 12), time.Minute);
			}
						
			if(_printSuffix)
			{
				Layout.Matrix.SetPixelColor(_wordProvider.GetSuffix().ToPointSurrogate(), GetClockColor().ToColorSurrogate());
			}
			
			Layout.Matrix.SetPixelColor(hour.ToPointSurrogate(), GetClockColor().ToColorSurrogate());
			Layout.Matrix.SetPixelColor(minutes.ToPointSurrogate(), GetClockColor().ToColorSurrogate());
						
			SetDetailMinutes(time.Minute % 5);

			if (time.Minute < 5)
			{
				Layout.Matrix.SetPixelColor(_wordProvider.GetPrefix().ToPointSurrogate(), GetClockColor().ToColorSurrogate());
			}

			Render();
			_oldMinute = time.Minute;
		}

		/// <summary>
		/// Sets the detail minutes
		/// </summary>
		/// <param name="minutes">Minutes</param>
		private void SetDetailMinutes(int minutes)
		{
			int BaseIndex = Layout.Minutes.Strip[0].PixelID;

			for (int i = 0; i <= minutes - 1; i++)
			{
				Layout.Minutes.Strip[3-i].PixelColor = GetClockColor().ToColorSurrogate();
			}
		}

		/// <summary>
		/// Returns a value which indicates if the time needs to be updated
		/// </summary>
		/// <param name="timeToRender"></param>
		/// <returns></returns>
		private bool IsUpdateRequired(DateTime timeToRender)
		{
			return (_oldMinute != timeToRender.Minute);
		}

		public bool GetShowSuffix()
		{
			return _printSuffix;
		}

		public void SetShowSuffix(bool value)
		{
			_printSuffix = value;

			_oldMinute = _oldMinute - 1;
			SetTime(DateTime.Now);
		}
		
	}
}
