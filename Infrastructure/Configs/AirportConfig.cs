using Domain.Aggregation.Airports;

namespace Infrastructure.Configs;

public class AirportConfig : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.Property(e => e.Code)
            .IsUnicode(false)
            .HasMaxLength(3);

        builder.Property(e => e.Name)
            .HasMaxLength(100);
        
        builder.HasIndex(e => e.Code).IsUnique();
    }
}