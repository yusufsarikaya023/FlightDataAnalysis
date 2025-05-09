using Microsoft.Extensions.Configuration;

namespace Domain;

public static class ConfigFactory
{
    public static IConfigurationRoot GetConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", true, true)
            .Build();
    }
}