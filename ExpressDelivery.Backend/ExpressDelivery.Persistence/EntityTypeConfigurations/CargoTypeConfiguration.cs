using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class CargoTypeConfiguration : IEntityTypeConfiguration<CargoType>
    {
        public void Configure(EntityTypeBuilder<CargoType> builder)
        {
            builder.HasKey(cargoType => cargoType.Id);
            builder.HasIndex(cargoType => cargoType.Id).IsUnique();
            builder.Property(cargoType => cargoType.Id);
            builder.Property(cargoType => cargoType.Name).IsRequired().HasMaxLength(50);
            builder.Property(cargoType => cargoType.Code).HasMaxLength(20);
            builder.Property(cargoType => cargoType.IsActual).IsRequired();
            builder.Property(cargoType => cargoType.Ts).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
