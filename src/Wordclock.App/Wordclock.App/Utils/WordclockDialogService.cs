using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.App.Utils
{
	class WordclockDialogService : IWordclockDialogService
	{
		private IPageDialogService _dialogService;

		public WordclockDialogService(IPageDialogService dialogService)
		{
			_dialogService = dialogService;
		}

		public Task ShowError(string message)
		{
			return _dialogService.DisplayAlertAsync("Fehler", message, "Ok");
		}

		public Task ShowError(Exception ex)
		{
			return ShowError(ex.Message);
		}

		public Task ShowInfo(string message)
		{
			return _dialogService.DisplayAlertAsync("Info", message, "Ok");
		}
	}
}
