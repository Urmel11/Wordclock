using System.Collections.Generic;
using System.Linq;
using Wordclock.Core.Layout;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Core.Plugin
{
	public class PluginManager
	{
		private IRenderEngine _renderEngine;
		private IPluginLayoutBuilder _layoutBuilder;
		private BasePlugin _activePlugin;
		private List<BasePlugin> _plugins;

		public PluginManager(IRenderEngine engine, IPluginLayoutBuilder layoutBuilder)
		{
			_renderEngine = engine;
			_layoutBuilder = layoutBuilder;
			_plugins = new List<BasePlugin>();

			RegisterPlugins();
		}

		public void ChangeActivePlugin<T>() where T: BasePlugin
		{
			_activePlugin?.DetachRenderEngine();

			_activePlugin = GetPlugin<T>();

			_activePlugin?.AttachRenderEngine(_renderEngine);
		}

		public T GetPlugin<T>() where T : BasePlugin
		{
			return (T)_plugins.Where(x => x.GetType().Equals(typeof(T))).FirstOrDefault();
		}

		private void RegisterPlugins()
		{
			_plugins.Add(new Clock(_layoutBuilder.CreateLayout()));
		}
	}
}
