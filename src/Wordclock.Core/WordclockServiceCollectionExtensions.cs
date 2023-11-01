using Microsoft.Extensions.DependencyInjection;
using Wordclock.Core.Layout;
using Wordclock.Core.Plugin;

namespace Wordclock.Core
{
	public static class WordclockServiceCollectionExtensions
	{
		public static IWordclockRegistration AddWordclock(this IServiceCollection services)
		{
			services.AddTransient<ILayoutFactory, LayoutFactory>();
			services.AddTransient<ITimeWordProvider, TimeWordGerman>();
			services.AddSingleton<PluginManager>();
			services.AddHostedService<WordclockHostedService>();

			return new WordclockRegistration(services);
		}
	}
}
