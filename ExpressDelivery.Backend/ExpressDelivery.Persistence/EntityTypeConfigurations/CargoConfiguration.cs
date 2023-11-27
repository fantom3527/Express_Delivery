using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("Cargo");
            builder.HasKey(cargo => cargo.Id);
            builder.HasIndex(cargo => cargo.Id).IsUnique();
            builder.Property(cargo => cargo.Id).HasColumnName("Id");
            builder.HasOne(cargo => cargo.Order)
                   .WithMany(order => order.Cargos)
                   .HasForeignKey(cargo => cargo.OrderId);
            builder.Property(cargo => cargo.OrderId).HasColumnName("Order_Id").IsRequired(false);
            builder.HasOne(cargo => cargo.CargoType)
                   .WithMany()
                   .HasForeignKey(cargo => cargo.CargoTypeId);
            builder.Property(cargo => cargo.CargoTypeId).HasColumnName("CargoType_Id").IsRequired();
            builder.Property(cargo => cargo.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(cargo => cargo.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(cargo => cargo.Ts).HasColumnName("TS").HasColumnType("DATETIME").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
