using Domain.Aggregation.AirCrafts;

namespace Infrastructure.Configs;

public class AirCraftConfig : IEntityTypeConfiguration<AirCrafts>
{
    public void Configure(EntityTypeBuilder<AirCrafts> builder)
    {
        builder.Property(e => e.RegistrationNumber)
            .IsUnicode(false)
            .HasMaxLength(10);
    }
}