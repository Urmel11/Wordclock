using System.ServiceModel;
using Wordclock.Shared.SharedInterfaces;

namespace Wordclock.Core.WordclockManagement
{
	[ServiceContract]
	public interface IWordclockService : ISettingsService, IClockService, IConnectionService
	{
	}
}
