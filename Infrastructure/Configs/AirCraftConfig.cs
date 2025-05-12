using Domain.Aggregation.AirCrafts;

namespace Infrastructure.Configs;

/// <summary>
/// Configuration for the AirCraft entity.
/// </summary>
public class AirCraftConfig : IEntityTypeConfiguration<AirCraft>
{
    public void Configure(EntityTypeBuilder<AirCraft> builder)
    {
        builder.Property(e => e.RegistrationNumber)
            .IsUnicode(false)
            .HasMaxLength(10);
        
        builder.HasIndex(e=> e.RegistrationNumber).IsUnique();
    }
}