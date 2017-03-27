using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordclock.Mobile
{
    interface IMessageAlerter
    {
        void ShowMessage(string message);

        void ShowError(string message);

        void ShowError(Exception ex);
        
    }
}
