using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock
{
	public partial class WordclockService : ServiceBase
	{
		public WordclockService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			Core.Wordclock.Startup(new StartupHandler());
		}

		protected override void OnStop()
		{
			Core.Wordclock.Shutdown();
		}
	}
}
