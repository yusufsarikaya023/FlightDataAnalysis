using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegister
{
    public static void InjectInfrastructure(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", true, true)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<Context>(x => x.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention()
        );
    }
}