using System;
using Wordclock.Core.Utils;

namespace Wordclock.Core.Tests.Utils
{
	class FakeTimeProvider : ITimeProvider
	{
		public DateTime Time { get; set; }

		public DateTime GetDateTime()
		{
			return Time;
		}
	}
}
