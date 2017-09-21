using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared;
using Wordclock.Shared.Services;

namespace Wordclock.App.ClientProxies
{
	class ClockServiceProxy : Proxy<IClockService>, IClockService
	{
		public ClockServiceProxy(IEndpointConfigurationFactory configurationFactory) : base(configurationFactory)	{ }
		
		public bool GetShowPrefix()
		{
			return CreateInstance().GetShowPrefix();
		}

		public void SetShowPrefix(bool value)
		{
			CreateInstance().SetShowPrefix(value);
		}

		public void SetClockColor(ColorSurrogate color)
		{
			CreateInstance().SetClockColor(color);
		}

		public ColorSurrogate GetClockColor()
		{
			return CreateInstance().GetClockColor();
		}
				
	}
}
