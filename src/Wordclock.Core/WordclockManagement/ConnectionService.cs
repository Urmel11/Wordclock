using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.Core.WordclockManagement
{
	public partial class WordclockService : IConnectionService
	{
		public bool IsConnectionEstablished()
		{
			return true;
		}
	}
}
