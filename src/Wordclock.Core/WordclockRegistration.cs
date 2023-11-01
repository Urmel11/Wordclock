using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Wordclock.Core.Plugin;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Core
{
	public class WordclockRegistration : IWordclockRegistration
	{
		private readonly IServiceCollection _serviceCollection;
		public WordclockRegistration(IServiceCollection serviceCollection)
		{
			_serviceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
		}

		public IWordclockRegistration WithPluginsOfAssembly<T>()
		{
			var pluginTypes = typeof(T).Assembly.GetTypes().Where(x => !x.IsAbstract && x.IsAssignableTo(typeof(BasePlugin))).ToList();

			pluginTypes.ForEach(x => _serviceCollection.AddSingleton(typeof(BasePlugin), x));

			return this;
		}

		public IWordclockRegistration WithRenderEngine<T>() where T : class, IRenderEngine
		{
			_serviceCollection.AddSingleton<IRenderEngine, T>();

			return this;
		}
	}
}
