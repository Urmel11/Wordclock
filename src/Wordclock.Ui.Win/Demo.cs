using Microsoft.Extensions.DependencyInjection;
using Wordclock.Core.Plugin;
using Wordclock.Core.Plugin.Clock;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Ui.Win
{
	public partial class Demo : Form
	{
		private PluginManager _pluginManager = default!;
		private PowerStateRenderEngineDecorator _powerStateRenderEngine = default!;
		private readonly IServiceProvider _serviceProvider;
		
		public Demo(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			_pluginManager = _serviceProvider.GetRequiredService<PluginManager>();
			_powerStateRenderEngine = _serviceProvider.GetRequiredService<PowerStateRenderEngineDecorator>();
			EnablePluginButtons();
			base.OnShown(e);
		}

		private void EnablePluginButtons()
		{
			var activePlugin = _pluginManager.GetActivePlugin();
			if (activePlugin is null)
				return;

			btnClock.Enabled = !activePlugin.GetType().Equals(typeof(Clock));
			btnKnightRider.Enabled = !activePlugin.GetType().Equals(typeof(KnightRider));
		}

		private void ChangePlugin<T>() where T : BasePlugin
		{
			_pluginManager.ChangeActivePlugin<T>();
			EnablePluginButtons();
		}

		private void btnClock_Click(object sender, EventArgs e)
		{
			ChangePlugin<Clock>();
		}

		private void btnKnightRider_Click(object sender, EventArgs e)
		{
			ChangePlugin<KnightRider>();
		}

		private void btnTogglePowerState_Click(object sender, EventArgs e)
		{
			_powerStateRenderEngine.TogglePowerState();
		}
	}
}
