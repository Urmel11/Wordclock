using Microsoft.Extensions.Hosting;
using WindowsFormsLifetime;
using Wordclock.Core;
using Wordclock.Core.Plugin.Clock;

namespace Wordclock.Ui.Win
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static async Task Main()
		{
			var host = Host.CreateDefaultBuilder()
				.UseWindowsFormsLifetime<Demo>()
				.ConfigureServices(x => x.AddWordclock()
										.WithRenderEngine<UiRenderEngine>()
										.WithPluginsOfAssembly<Clock>())
				.Build();

			await host.RunAsync();
		}
	}
}
