using Domain;
using Domain.Aggregation.AirCrafts;
using Domain.Aggregation.Airports;
using Domain.Aggregation.Flights;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        var connectionString = ConfigFactory.GetConfiguration().GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }

    public DbSet<AirCrafts> AirCrafts { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Flight> Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}