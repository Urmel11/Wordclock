// Helpers/Settings.cs
using Refractored.Xam.Settings;
using Refractored.Xam.Settings.Abstractions;

namespace Wordclock.Mobile.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SERVER_KEY = "server";
    private static readonly string SERVER_DEFAULT = string.Empty;

	private const string PORT_KEY = "port";
	private static readonly int PORT_DEFAULT = 0;

		#endregion


	public static string Server
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(SERVER_KEY, SERVER_DEFAULT);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(SERVER_KEY, value);
      }
    }

	public static int Port
	{
		get
		{
			return AppSettings.GetValueOrDefault<int>(PORT_KEY, PORT_DEFAULT);
		}
		set
		{
			AppSettings.AddOrUpdateValue<int>(PORT_KEY, value);
		}
	}

	}
}