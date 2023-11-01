using System.Collections.Generic;
using System.Linq;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Core.Plugin
{
	public class PluginManager
	{
		private IRenderEngine _renderEngine;
		private BasePlugin? _activePlugin;
		private List<BasePlugin> _plugins;

		public PluginManager(IRenderEngine engine, IEnumerable<BasePlugin> plugins)
		{
			_renderEngine = engine;
			_plugins = new List<BasePlugin>(plugins);
		}

		public void ChangeActivePlugin<T>() where T: BasePlugin
		{
			_activePlugin?.DetachRenderEngine();

			_activePlugin = GetPlugin<T>();

			_activePlugin?.AttachRenderEngine(_renderEngine);
		}

		public BasePlugin? GetActivePlugin()
		{
			return _activePlugin;
		}

		public T? GetPlugin<T>() where T : BasePlugin
		{
			return (T?)_plugins.FirstOrDefault(x => x.GetType().Equals(typeof(T)));
		}
	}
}
