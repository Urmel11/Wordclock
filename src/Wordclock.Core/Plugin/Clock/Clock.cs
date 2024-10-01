using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Wordclock.Core.Layout;

namespace Wordclock.Core.Plugin.Clock
{
	/// <summary>
	/// Plugin for showing the time 
	/// </summary>
	public class Clock : BasePlugin
	{
		private ITimeWordProvider _wordProvider;
		private Color _color;
		private bool _printPrefix;

		private int _oldMinute;

		public Clock(ILayoutFactory layoutFactory, ITimeWordProvider wordProvider) : base(layoutFactory)
		{
			_wordProvider = wordProvider;
			_color = Color.White;
			_printPrefix = true;
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

			if (_printPrefix)
			{
				Layout.Matrix.SetPixelColor(_wordProvider.GetPrefix(), GetClockColor());
			}

			Layout.Matrix.SetPixelColor(hour, GetClockColor());
			Layout.Matrix.SetPixelColor(minutes, GetClockColor());

			SetDetailMinutes(time.Minute % 5);

			if (time.Minute < 5)
			{
				Layout.Matrix.SetPixelColor(_wordProvider.GetSuffix(), GetClockColor());
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
			for (int i = 0; i <= minutes - 1; i++)
			{
				Layout.Minutes[i].PixelColor = GetClockColor();
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

		public bool GetShowPrefix()
		{
			return _printPrefix;
		}

		public void SetShowPrefix(bool value)
		{
			_printPrefix = value;

			_oldMinute = _oldMinute - 1;
			SetTime(DateTime.Now);
		}

		protected override async Task Execute(CancellationToken cancellationToken)
		{
			_oldMinute = -1;

			while (!cancellationToken.IsCancellationRequested)
			{
				SetTime(DateTime.Now);

				await Task.Delay(5 * 1000, cancellationToken);
			}
		}
	}
}
