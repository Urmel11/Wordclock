using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.SharedInterfaces;
using System.Drawing;

namespace Wordclock.ManagementService
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class WordclockService : IWordclockService
	{	
		public bool IsConnectionEstablished()
		{
			return true;
		}

		public SettingsData Data()
		{
			var result = new SettingsData();

			result.IsWordclockOn = (Core.Wordclock.PowerManager.PowerState == PowerState.On);
			result.UpTime = DateTime.Now.Subtract(ManagementStartupCommand.StartTime);

			return result;
		}

		public void SetPowerState(PowerState state)
		{
			if(state == PowerState.On)
			{
				Core.Wordclock.PowerManager.PowerOn();
			}
			else
			{
				Core.Wordclock.PowerManager.PowerOff();
			}
		}

		public ClockSettings GetWordclockSettings()
		{
			var result = new ClockSettings();
			var plugin = Core.Wordclock.PluginHandler.GetPlugin<Core.Plugin.Clock>();

			result.ClockColor = plugin.GetClockColor().ToColorSurrogate();
			result.UseSuffix = plugin.GetShowSuffix();

			return result;
		}
	}
}
