using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.ToTable("orderHistory");
            builder.HasKey(orderHistory => orderHistory.Id);
            builder.HasIndex(orderHistory => orderHistory.Id).IsUnique();
            builder.Property(orderHistory => orderHistory.Id).HasColumnName("Id");
            builder.HasOne(orderHistory => orderHistory.Order)
                   .WithMany(order => order.OrderHistories)
                   .HasForeignKey(orderHistory => orderHistory.OrderId);
            builder.Property(orderHistory => orderHistory.OrderId).HasColumnName("Order_Id").IsRequired();
            builder.Property(orderHistory => orderHistory.NameMethod).HasColumnName("NameMethod").IsRequired().HasMaxLength(50);
            builder.Property(orderHistory => orderHistory.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(orderHistory => orderHistory.Ts).HasColumnName("TS").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
