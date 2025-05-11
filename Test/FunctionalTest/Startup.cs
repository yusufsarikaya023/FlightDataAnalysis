using Application;
using Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Test.FunctionalTest;

public class Startup(string connString): FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseNpgsql(connString)
                .UseSnakeCaseNamingConvention();
        });

        builder.Services.InjectInfrastructure();
        builder.Services.InjectApplication();
        builder.Services.AddHttpContextAccessor();
    }
}