using System.ServiceModel;
using System.Drawing;

namespace Wordclock.Shared.Services
{
	[ServiceContract]
	public interface IClockService
	{
		/// <summary>
		/// Defines if the prexix needs to be shown
		/// </summary>
		/// <param name="value"></param>
		[OperationContract]
		void SetShowPrefix(bool value);

		[OperationContract]
		bool GetShowPrefix();

		/// <summary>
		/// Sets the color of the clock
		/// </summary>
		/// <param name="color"></param>
		[OperationContract]
		void SetClockColor(Color color);


		/// <summary>
		/// Returns the color of the clock
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		Color GetClockColor();
	}
}
