using System.Threading;
using System.Threading.Tasks;
using Wordclock.Core.Layout;
using Wordclock.Core.RenderEngine;

namespace Wordclock.Core.Plugin
{
	public abstract class BasePlugin
	{
		private IRenderEngine? _renderEngine;
		private CancellationTokenSource? _cancellationTokenSource;

		public BasePlugin(ILayoutFactory layoutFactor)
		{
			Layout = layoutFactor.CreateLayout();
		}

		public void AttachRenderEngine(IRenderEngine engine)
		{
			_renderEngine = engine;
			_cancellationTokenSource = new CancellationTokenSource();

			Execute(_cancellationTokenSource.Token);
		}

		public void DetachRenderEngine()
		{
			_cancellationTokenSource?.Cancel();
			_renderEngine = null;
		}

		public void Render()
		{
			_renderEngine?.Render(Layout.GetChangedPixels());
		}

		protected abstract Task Execute(CancellationToken cancellationToken);

		public PluginLayout Layout { get; private set; }
	}
}
