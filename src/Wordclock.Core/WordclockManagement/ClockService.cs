using System.Drawing;
using Wordclock.Shared;
using Wordclock.Shared.Services;

namespace Wordclock.Core.WordclockManagement
{
	public partial class WordclockService : IClockService
	{
		public void SetShowPrefix(bool value)
		{
			var plugin = Core.Wordclock.PluginHandler.GetPlugin<Core.Plugin.Clock>();

			plugin.SetShowPrefix(value);
		}

		public bool GetShowPrefix()
		{
			return Wordclock.PluginHandler.GetPlugin<Core.Plugin.Clock>().GetShowPrefix();
		}

		public void SetClockColor(Color newColor)
		{
			var plugin = Core.Wordclock.PluginHandler.GetPlugin<Core.Plugin.Clock>();
			plugin.SetClockColor(newColor);
		}
		
		public Color GetClockColor()
		{
			var plugin = Core.Wordclock.PluginHandler.GetPlugin<Core.Plugin.Clock>();
			return plugin.GetClockColor();
		}
	}
}
