using System.ServiceModel;

namespace Wordclock.Shared.SharedInterfaces
{
	[ServiceContract]
	public interface IConnectionService
	{
		/// <summary>
		/// Returns a value which indicate if the connection was successfuly established
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		bool IsConnectionEstablished();
	}
}
