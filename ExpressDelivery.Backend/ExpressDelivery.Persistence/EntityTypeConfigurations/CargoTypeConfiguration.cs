using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class CargoTypeConfiguration : IEntityTypeConfiguration<CargoType>
    {
        public void Configure(EntityTypeBuilder<CargoType> builder)
        {
            builder.ToTable("CargoType");
            builder.HasKey(cargoType => cargoType.Id);
            builder.HasIndex(cargoType => cargoType.Id).IsUnique();
            builder.Property(cargoType => cargoType.Id).HasColumnName("Id");
            builder.Property(cargoType => cargoType.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(cargoType => cargoType.Code).HasColumnName("Code").HasMaxLength(20);
            builder.Property(cargoType => cargoType.IsActual).HasColumnName("IsActual").IsRequired();
            builder.Property(cargoType => cargoType.Ts).HasColumnName("TS").HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("DATETIME");
        }
    }
}
