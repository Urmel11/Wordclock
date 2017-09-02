using System.ServiceModel;

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

		/// <summary>
		/// Sets the color of the clock
		/// </summary>
		/// <param name="color"></param>
		[OperationContract]
		void SetClockColor(ColorSurrogate color);

		/// <summary>
		/// Returns the settings of the clock
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		ClockSettings GetWordclockSettings();
	}
}
