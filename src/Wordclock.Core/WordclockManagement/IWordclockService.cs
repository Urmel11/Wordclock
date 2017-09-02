using System.ServiceModel;
using Wordclock.Shared.Services;

namespace Wordclock.Core.WordclockManagement
{
	[ServiceContract]
	public interface IWordclockService : IInfoService, IClockService, IConnectionService
	{
	}
}
