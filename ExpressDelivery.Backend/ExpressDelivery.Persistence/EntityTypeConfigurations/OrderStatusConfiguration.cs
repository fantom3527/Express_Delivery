using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatus");
            builder.HasKey(orderStatus => orderStatus.Id);
            builder.HasIndex(orderStatus => orderStatus.Id).IsUnique();
            builder.Property(orderStatus => orderStatus.Id).HasColumnName("Id");
            builder.Property(orderStatus => orderStatus.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(orderStatus => orderStatus.Code).HasColumnName("Code").IsRequired().HasMaxLength(20);
            builder.Property(orderStatus => orderStatus.IsActual).HasColumnName("IsActual").IsRequired();
            builder.Property(orderStatus => orderStatus.Ts).HasColumnName("TS").HasColumnType("DATETIME").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
