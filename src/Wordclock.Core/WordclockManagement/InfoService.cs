using System;
using System.Diagnostics;
using System.Reflection;
using Wordclock.Shared.Services;

namespace Wordclock.Core.WordclockManagement
{
	public partial class WordclockService : IInfoService
	{
		public InfoData GetInformationData()
		{
			var startTime = Process.GetCurrentProcess().StartTime;

			var result = new InfoData()
			{
				UpTime = DateTime.Now.Subtract(startTime),
				StartTime = startTime,
				WordclockVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString()
			};

			return result;
		}
	}
}
