using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Test.FunctionalTest;

/// <summary>
/// This class is responsible for setting up the test environment.
/// </summary>
public class FunctionFixture: IDisposable, IAsyncDisposable
{
    public readonly IHost Host;
    private static readonly object Lock = new();
    private static bool _databaseInitialized;
    public Context Context;
    
    public T GetService<T>() where T : notnull
    {
        return Host.Services.GetRequiredService<T>();
    }

    public FunctionFixture()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", true, true)
            .Build();

        var connectionString = configuration.GetConnectionString("FunctionalConnection");

        var startup = new Startup(connectionString!);
        Host = new HostBuilder().ConfigureWebJobs(startup.Configure).Build();
        Host.Start();

        lock (Lock)
        {
            if (_databaseInitialized) return;
            var options = new DbContextOptionsBuilder<Context>()
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                .Options;
            using (var context = new Context(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
            Context = new Context(options);

            _databaseInitialized = true;
        }
    }

    public void Dispose()
    {
        Host.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (Host is IAsyncDisposable hostAsyncDisposable)
            await hostAsyncDisposable.DisposeAsync();
        else
            Host.Dispose();
    }
}