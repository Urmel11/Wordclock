using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.ManagementService
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class WordclockService : IWordclockService
	{
		public string TestConnect()
		{
			return "Current date: " + DateTime.Now;
		}
	}
}
