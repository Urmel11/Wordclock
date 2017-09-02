using Microsoft.Practices.Unity;
using Prism.Services;
using Prism.Unity;
using System;
using Wordclock.App.ClientProxies;
using Wordclock.App.Utils;
using Wordclock.App.Views;
using Wordclock.Shared.Services;
using Xamarin.Forms;

namespace Wordclock.App
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			
			NavigationService.NavigateAsync("ConnectPage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<NavigationPage>();
			Container.RegisterTypeForNavigation<ConnectPage>();
			Container.RegisterTypeForNavigation<MenuPage>();
			Container.RegisterTypeForNavigation<InfoPage>();

			Container.RegisterType<IWordclockDialogService, WordclockDialogService>();
			Container.RegisterType<IConnectionService, ConnectionServiceProxy>();
			Container.RegisterType<IInfoService, InfoServiceProxy>();
			Container.RegisterType<IEndpointConfigurationFactory, EndpointConfigurationFactory>();
		}
	}
}
