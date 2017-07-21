using System;

namespace Configuration.EnvironmentProvider
{
    public class EnvironmentProvider : IEnvironmentProvider
    {
        public string EnvironmentName => Environment.GetEnvironmentVariable(ConfigurationConstants.EnvironmentVariableName);
        public string SettingsPath => Environment.GetEnvironmentVariable(ConfigurationConstants.SettingsPathVariableName);
    }
}