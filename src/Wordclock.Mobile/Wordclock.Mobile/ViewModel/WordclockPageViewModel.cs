using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.Model;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.Mobile.ViewModel
{
	class WordclockPageViewModel
	{
		private IView _view;

		public WordclockPageViewModel(IView view)
		{
			_view = view;
			InitializeData();
		}

		private void InitializeData()
		{
			var instance = ServiceConnector.CreateInstance<IWordclockService>();

			try
			{
				Settings = instance.GetWordclockSettings();
			}
			catch(Exception ex)
			{
				_view.ShowError(ex.ToString());
			}
		}

		public ColorSurrogate ClockColor
		{
			get
			{
				return Settings.ClockColor;
			}
			set
			{
				Settings.ClockColor = value;
			}
		}

		public ClockSettings Settings { get; set; }
	}
}
