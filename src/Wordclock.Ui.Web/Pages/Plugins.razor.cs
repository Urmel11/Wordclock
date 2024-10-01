using Microsoft.AspNetCore.Components;
using Wordclock.Core.Plugin;

namespace Wordclock.Ui.Web.Pages
{
	public partial class Plugins
	{
		[Inject]
		public PluginManager? PluginManager { get; set; }

		public void OnClockClicked()
		{
			PluginManager?.ChangeActivePlugin<Core.Plugin.Clock.Clock>();
		}

		public void OnKnightRiderClicked()
		{
			PluginManager?.ChangeActivePlugin<KnightRider>();
		}

	}
}
