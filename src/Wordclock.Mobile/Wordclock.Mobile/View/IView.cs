using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Mobile
{
	interface IView
	{
		void ShowError(string message);

		void ShowMessages(string message);
		
	}
}
