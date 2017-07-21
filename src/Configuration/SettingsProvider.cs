using System;
using Configuration.EnvironmentProvider;
using Microsoft.Extensions.Configuration;

namespace Configuration
{
    public class SettingsProvider
    {
        public static IConfigurationRoot GetConfigurationRoot(IEnvironmentProvider environmentProvider)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environmentProvider.SettingsPath)
                .AddJsonFile(ConfigurationConstants.SettingsFileName)
                .AddJsonFile(string.Format(ConfigurationConstants.SettingsEnviromentFileName, environmentProvider.EnvironmentName), optional: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }      
    }
}