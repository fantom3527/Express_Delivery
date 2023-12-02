using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(cargo => cargo.Id);
            builder.HasIndex(cargo => cargo.Id).IsUnique();
            builder.HasOne(cargo => cargo.Order)
                   .WithMany(order => order.Cargos)
                   .HasForeignKey(cargo => cargo.OrderId);
            builder.Property(cargo => cargo.OrderId).IsRequired(false);
            builder.HasOne(cargo => cargo.CargoType)
                   .WithMany()
                   .HasForeignKey(cargo => cargo.CargoTypeId);
            builder.Property(cargo => cargo.CargoTypeId).IsRequired();
            builder.Property(cargo => cargo.Name).IsRequired().HasMaxLength(50);
            builder.Property(cargo => cargo.Description).HasMaxLength(1000);
            builder.Property(cargo => cargo.Ts).HasColumnType("DATETIME").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
