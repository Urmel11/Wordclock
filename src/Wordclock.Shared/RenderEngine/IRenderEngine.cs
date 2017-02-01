using System.Collections.Generic;
using Wordclock.Base.Layout;

namespace Wordclock.Base.RenderEngine
{
	/// <summary>
	/// Interface provides the rendering engine
	/// </summary>
	public interface IRenderEngine
	{
		void Render(IEnumerable<Pixel> pixelsToRender);
	}
}
