using Prism.Mvvm;
using System;
using Wordclock.App.Utils;
using Wordclock.Shared.Services;
using Xamarin.Forms;

namespace Wordclock.App.ViewModels
{
	public class InfoPageViewModel : BindableBase, IRefreshable
	{
		private IInfoService _infoService;
		private IWordclockDialogService _dialogService;
		private IUpdateService _updateService;
		private IResourceService _resourceService;

		public InfoPageViewModel(IInfoService infoService,
									IWordclockDialogService dialogService,
									IUpdateService updateService,
									IResourceService resourceService)
		{
			_infoService = infoService;
			_dialogService = dialogService;
			_updateService = updateService;
			_resourceService = resourceService;

			Transfer = new Command(() => TransferFiles(), () => UpdateRequired());

			Refresh();
		}

		private bool UpdateRequired()
		{
			try
			{
				var appVersion = "";//_versionService.Version;

				return _updateService.IsUpdateRequired(appVersion);
			}
			catch (Exception ex)
			{
				_dialogService.ShowError(ex);
			}

			return false;
		}

		private void TransferFiles()
		{
			try
			{
				var resources = _resourceService.GetEmbeddedResources();
				
				_updateService.TransferContent(resources, true);

				_dialogService.ShowInfo("Bitte starte die Wordclock neu, damit die Softwareaktualisierung wirksam wird.");
			}
			catch (Exception ex)
			{
				_dialogService.ShowError(ex);
			}
		}

		public void Refresh()
		{
			try
			{
				Information = _infoService.GetInformationData();
				
			}catch(Exception ex)
			{
				_dialogService.ShowError(ex);
			}
		}
		
		public string AppVersion
		{
			get
			{
				return "";// _versionService.Version;
			}
		}
			
		public InfoData Information { get; set; }

		public Command Transfer { get; set; }
	}
}
