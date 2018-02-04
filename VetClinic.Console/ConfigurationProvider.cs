using System.Configuration;

namespace VetClinic.Console
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public bool IsTestEnvironment
            => bool.Parse(ConfigurationManager.AppSettings["IsTestEnvironment"]);
    }
}
