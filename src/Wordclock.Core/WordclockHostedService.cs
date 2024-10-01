using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Wordclock.Core.Plugin;
using Wordclock.Core.Plugin.Clock;

namespace Wordclock.Core
{
	public class WordclockHostedService : BackgroundService
	{
		private PluginManager _pluginManager;

		public WordclockHostedService(PluginManager pluginManager)
		{
			_pluginManager = pluginManager ?? throw new ArgumentNullException(nameof(pluginManager));
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_pluginManager.ChangeActivePlugin<Clock>();
			return Task.CompletedTask;
		}
	}
}
