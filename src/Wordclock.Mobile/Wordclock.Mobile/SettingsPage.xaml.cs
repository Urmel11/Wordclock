using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Wordclock.Mobile
{
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			InitializeComponent();

			var table = new TableView();

			table.Intent = TableIntent.Form;

			var section = new TableSection("Energie");
			section.Add(new SwitchCell() { Text = "Status"});

			table.Root.Add(section);

			Content = table;
		}
	}
}
