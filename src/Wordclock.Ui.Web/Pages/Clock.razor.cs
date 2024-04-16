using Microsoft.AspNetCore.Components;
using System.Drawing;
using Wordclock.Core.Plugin;

namespace Wordclock.Ui.Web.Pages
{
    public partial class Clock
    {
        [Inject]
        public PluginManager? PluginManager { get; set; }

        public bool ClockIsActive => PluginManager?.IsPluginActive<Core.Plugin.Clock>() ?? false;
        
        private void OnClockStatusToggled()
        {
            PluginManager?.ChangeActivePlugin<Core.Plugin.Clock>();
        }
        
        public string GetClockColor()
        {
            var clock = PluginManager?.GetPlugin<Core.Plugin.Clock>();
            if (clock is null)
                return "#FFFFFF";

            var color = clock.GetClockColor();

            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
        private void OnColorChanged(ChangeEventArgs e)
        {
            if (e is null || e.Value is null)
                return;

            var clock = PluginManager?.GetPlugin<Core.Plugin.Clock>();
            if (clock is null)
                return;

           var hex = e.Value.ToString()!.TrimStart('#');

            // Parse RGB components
            int r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            clock.SetClockColor(Color.FromArgb(r, g, b));
        }

    }
}
