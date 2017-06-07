using System;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.Core.WordclockManagement
{
	public partial class WordclockService : ISettingsService
	{
		public SettingsData Data()
		{
			var result = new SettingsData()
			{
				State = Core.Wordclock.PowerManager.PowerState,
				UpTime = DateTime.Now.Subtract(ManagementStartupCommand.StartTime),
				StartTime = ManagementStartupCommand.StartTime
			};
			return result;
		}

		public void SetPowerState(PowerState state)
		{
			if (state == PowerState.On)
			{
				Core.Wordclock.PowerManager.PowerOn();
			}
			else
			{
				Core.Wordclock.PowerManager.PowerOff();
			}
		}
	}
}
