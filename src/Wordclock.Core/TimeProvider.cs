using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Core
{
	class TimeProvider : ITimeProvider
	{
		public DateTime GetDateTime()
		{
			return DateTime.Now;
		}
	}
}
