using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;
using Wordclock.Base.RenderEngine;

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

		private BasePlugin GetPlugin<T>() where T : BasePlugin
		{
			return _plugins.Where(x => x.GetType().Equals(typeof(T))).FirstOrDefault();
		}

		private void RegisterPlugins()
		{
			_plugins.Add(new Clock(_layoutBuilder.CreateLayout()));
		}
	}
}
