using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.App.ViewModels
{
	public class ProgressBaseViewModel : BindableBase
	{
		private bool _isBusy = false;
		private bool _isNotBusy = true;

		/// <summary>
		/// Gets or sets a value which indicates if a task is running
		/// </summary>
		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				SetProperty(ref _isBusy, value);
				IsNotBusy = !_isBusy;
			}
		}

		/// <summary>
		/// Gets or sets a value which indicats that no task is running
		/// </summary>
		public bool IsNotBusy
		{
			get { return _isNotBusy; }
			private set { SetProperty(ref _isNotBusy, value); }
		}
	}
}
