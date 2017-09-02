using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Version.Plugin.Abstractions;
using Wordclock.App.Utils;
using Wordclock.Shared.Services;

namespace Wordclock.App.ViewModels
{
	public class InfoPageViewModel : BindableBase, IRefreshable
	{
		private IVersion _versionService;
		private IInfoService _infoService;
		private IWordclockDialogService _dialogService;

		public InfoPageViewModel(IVersion versionService,
									IInfoService infoService,
									IWordclockDialogService dialogService)
		{
			_versionService = versionService;
			_infoService = infoService;
			_dialogService = dialogService;

			Refresh();
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
				return _versionService.Version;
			}
		}
			
		public InfoData Information { get; set; }

	}
}
