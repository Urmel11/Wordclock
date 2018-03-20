using System;

namespace Wordclock.Core.Utils
{
	class TimeProvider : ITimeProvider
	{
		public DateTime GetDateTime()
		{
			return DateTime.Now;
		}
	}
}
