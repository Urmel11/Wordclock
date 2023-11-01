using Wordclock.Core.RenderEngine;

namespace Wordclock.Core
{
	public interface IWordclockRegistration
	{
		IWordclockRegistration WithRenderEngine<T>() where T : class, IRenderEngine;

		IWordclockRegistration WithPluginsOfAssembly<T>();
	}
}
