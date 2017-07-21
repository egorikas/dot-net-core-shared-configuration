namespace Configuration
{
    public class ConfigurationConstants
    {
        public static string SettingsPathVariableName => "SHAREDSETTINGS_LOCATION";
        public static string EnvironmentVariableName => "ASPNETCORE_ENVIRONMENT";
        public static string SettingsFileName => "appsettings.json";
        public static string SettingsEnviromentFileName => "appsettings.{0}.json";
    }
}