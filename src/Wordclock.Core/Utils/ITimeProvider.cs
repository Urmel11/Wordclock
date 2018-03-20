using System;

namespace Wordclock.Core.Utils
{
	public interface ITimeProvider
	{
		DateTime GetDateTime();
	}
}
