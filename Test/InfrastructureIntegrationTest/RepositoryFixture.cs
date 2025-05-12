using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Test.InfrastructureIntegrationTest;

/// <summary>
/// This class is responsible for setting up the test environment.
/// </summary>
public class RepositoryFixture: IDisposable, IAsyncDisposable
{
    private readonly Context _context;

    public RepositoryFixture()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", true, true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var options = new DbContextOptionsBuilder<Context>()
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention()
            .Options;

        _context = new Context(options);
        _context.Database.EnsureDeleted();
        _context.Database.Migrate();
    }
    
    public Context Context { get => _context; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}