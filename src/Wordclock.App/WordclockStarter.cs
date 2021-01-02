using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wordclock.Core.Plugin;

namespace Wordclock.App
{
	public class WordclockStarter : IHostedService
	{
		private PluginManager _pluginManager;

		public WordclockStarter(PluginManager pluginManager)
		{
			_pluginManager = pluginManager;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_pluginManager.ChangeActivePlugin<Clock>();
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
