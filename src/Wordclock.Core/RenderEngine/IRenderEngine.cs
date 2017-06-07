using System.Collections.Generic;
using Wordclock.Core.Layout;

namespace Wordclock.Core.RenderEngine
{
	/// <summary>
	/// Interface provides the rendering engine
	/// </summary>
	public interface IRenderEngine
	{
		void Render(IEnumerable<Pixel> pixelsToRender);
	}
}
