using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wordclock.Core;
using Wordclock.Core.PowerManagement;
using Wordclock.Core.RenderEngine;

namespace Wordclock.App.Pages
{
	public partial class Index
	{

		public bool IsOn => GetRenderManager()?.GetPowerState() == PowerState.On;

		[Inject]
		public IRenderEngine? RenderManager { get; set; }

		public void OnOnClicked()
		{
			GetRenderManager()?.SetPowerState(PowerState.On);
		}

		public void OnOffClicked()
		{
			GetRenderManager()?.SetPowerState(PowerState.Off);
		}

		private RenderManager? GetRenderManager() => (RenderManager as RenderManager); 
	}
}
