using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.App.Utils
{
	/// <summary>
	/// Service which is responsible to show dialog messages
	/// </summary>
	public interface IWordclockDialogService
	{
		/// <summary>
		/// Show the given error message
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		Task ShowError(string message);

		/// <summary>
		/// Show the exception as error
		/// </summary>
		/// <param name="ex"></param>
		/// <returns></returns>
		Task ShowError(Exception ex);

		/// <summary>
		/// Shows an info message
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		Task ShowInfo(string message);
	}
}
