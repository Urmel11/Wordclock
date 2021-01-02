using Microsoft.Extensions.DependencyInjection;
using Wordclock.Core.Layout;
using Wordclock.Core.Plugin;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Core
{
	public static class WordclockServiceCollectionExtensions
	{
		public static void AddWordclock(this IServiceCollection services)
		{
			services.AddTransient<ILayoutBuilder, DefaultLayoutBuilder>();
			services.AddTransient<IPluginLayoutBuilder, DefaultLayoutBuilder>();
			services.AddSingleton<IRenderEngine, ConsoleRenderEngine>();
			//services.AddSingleton<IRenderEngine, Ws2812BRenderEngine>();
			services.Decorate<IRenderEngine, RenderManager>();

			services.AddSingleton<PluginManager>();
		}
	}
}
