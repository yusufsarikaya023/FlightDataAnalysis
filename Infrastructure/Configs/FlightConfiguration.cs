using Domain.Aggregation.Flights;

namespace Infrastructure.Configs;

/// <summary>
/// Configuration for the Flight entity.
/// </summary>
public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.Property(e => e.FlightNumber)
            .IsUnicode(false)
            .HasMaxLength(10);

        builder.HasOne(e => e.AirCraft)
            .WithMany()
            .HasForeignKey(e => e.AirCraftId)
            .IsRequired();

        builder.HasOne(e => e.DepartureAirport)
            .WithMany()
            .HasForeignKey(e => e.DepartureAirportId)
            .IsRequired();

        builder.HasOne(e => e.ArrivalAirport)
            .WithMany()
            .HasForeignKey(e => e.ArrivalAirportId)
            .IsRequired();
    }
}