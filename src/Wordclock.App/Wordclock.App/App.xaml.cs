using Prism;
using Prism.Ioc;
using Prism.Unity;
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

		protected override void RegisterTypes(IContainerRegistry containterRegistry)
		{
			containterRegistry.RegisterForNavigation<NavigationPage>();
			containterRegistry.RegisterForNavigation<ConnectPage>();
			containterRegistry.RegisterForNavigation<MenuPage>();
			containterRegistry.RegisterForNavigation<InfoPage>();

			containterRegistry.Register<IWordclockDialogService, WordclockDialogService>();
			containterRegistry.Register<IConnectionService, ConnectionServiceProxy>();
			containterRegistry.Register<IInfoService, InfoServiceProxy>();
			containterRegistry.Register<IPowerService, PowerServiceProxy>();
			containterRegistry.Register<IEndpointConfigurationFactory, EndpointConfigurationFactory>();
			containterRegistry.RegisterForNavigation<PowerPage>();
			containterRegistry.RegisterForNavigation<ClockPage>();
			containterRegistry.Register<IClockService, ClockServiceProxy>();
			containterRegistry.RegisterForNavigation<ColorPickerPage>();
			containterRegistry.Register<IUpdateService, UpdateServiceProxy>();
			containterRegistry.Register<IResourceService, EmbeddedResourceService>();
			
		}
	}
}
