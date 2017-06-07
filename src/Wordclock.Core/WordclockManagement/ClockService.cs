using Wordclock.Shared;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.Core.WordclockManagement
{
	public partial class WordclockService : IClockService
	{
		public ClockSettings GetWordclockSettings()
		{
			var result = new ClockSettings();
			var plugin = Core.Wordclock.PluginHandler.GetPlugin<Core.Plugin.Clock>();

			result.ClockColor = plugin.GetClockColor().ToColorSurrogate();
			result.ShowPrefix = plugin.GetShowPrefix();

			return result;
		}

		public void SetShowPrefix(bool value)
		{
			var plugin = Core.Wordclock.PluginHandler.GetPlugin<Core.Plugin.Clock>();

			plugin.SetShowPrefix(value);
		}

		public void SetClockColor(ColorSurrogate newColor)
		{
			var plugin = Core.Wordclock.PluginHandler.GetPlugin<Core.Plugin.Clock>();
			plugin.SetClockColor(newColor.ToColor());
		}
	}
}
