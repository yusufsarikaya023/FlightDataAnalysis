using Domain.Aggregation.AirCrafts;

namespace Infrastructure.Configs;

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