using System.ServiceModel;

namespace Wordclock.Shared.Services
{
	[ServiceContract]
	public interface IInfoService
	{
		/// <summary>
		/// Returns general settings data
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		InfoData GetInformationData();
		
	}
}
