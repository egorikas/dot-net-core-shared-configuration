namespace Configuration.EnvironmentProvider
{
    public interface IEnvironmentProvider
    {
        string EnvironmentName { get;}
        string SettingsPath { get; }
    }
}