namespace VetClinic.Console
{
    public interface IConfigurationProvider
    {
        bool IsTestEnvironment { get; }
    }
}
