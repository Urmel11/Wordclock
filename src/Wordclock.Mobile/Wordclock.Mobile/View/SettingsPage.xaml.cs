using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Mobile.ViewModel;
using Wordclock.Shared.SharedInterfaces;
using Xamarin.Forms;

namespace Wordclock.Mobile
{
	public partial class SettingsPage : BaseContentPage
	{
		public SettingsPage()
		{
			BindingContext = new SettingsPageViewModel(this);
			InitializeComponent();

			var table = new TableView();

			table.Intent = TableIntent.Settings;

			var energyOptions = new TableSection("Energie");
			var switchCell = new SwitchCell();
			switchCell.Text = "Status";
			switchCell.SetBinding(SwitchCell.OnProperty, new Binding(nameof(SettingsPageViewModel.IsPowerOn)));
			
			energyOptions.Add(switchCell);

			var commonOptions = new TableSection("Allgemein");
			var uptimeCell = new TextCell();
			uptimeCell.Text = "Uptime";

			var bindingPath = String.Format("{0}.{1}", nameof(SettingsPageViewModel.Data), nameof(SettingsData.UpTime));

			uptimeCell.SetBinding(TextCell.DetailProperty, new Binding(bindingPath, converter:new TimespanToDayConverter()));
			commonOptions.Add(uptimeCell);
			
			table.Root.Add(energyOptions);
			table.Root.Add(commonOptions);

			Content = table;
		}
	}
}
