using System.ServiceModel;

namespace Wordclock.Shared.SharedInterfaces
{
	[ServiceContract]
	public interface ISettingsService
	{
		/// <summary>
		/// Returns general settings data
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		SettingsData Data();

		/// <summary>
		/// Turn on/off the wordclock matrix
		/// </summary>
		/// <param name="state"></param>
		[OperationContract]
		void SetPowerState(PowerState state);

	}
}
