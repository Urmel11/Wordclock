using System.Collections.Generic;
using Wordclock.Core.Layout;

namespace Wordclock.Core.RenderEngine
{
	public class NoOpRenderEngine : IRenderEngine
	{
		public void Render(IEnumerable<Pixel> pixelsToRender)
		{

		}
	}
}
