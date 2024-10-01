using Microsoft.AspNetCore.Components;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Ui.Web.Shared
{
	public partial class MainLayout
	{

		[Inject]
		public PowerStateRenderEngineDecorator RenderEngine { get; private set; } = default!;

		public string ButtonStyle
		{
			get
			{
				if (RenderEngine.IsOn)
					return "btn-danger";

				return "btn-success";
			}
		}
		public void TogglePowerState()
		{
			RenderEngine.TogglePowerState();
		}
	}
}
