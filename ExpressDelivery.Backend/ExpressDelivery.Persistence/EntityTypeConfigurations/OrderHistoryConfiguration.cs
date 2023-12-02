using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.HasKey(orderHistory => orderHistory.Id);
            builder.HasIndex(orderHistory => orderHistory.Id).IsUnique();
            builder.Property(orderHistory => orderHistory.Id);
            builder.HasOne(orderHistory => orderHistory.Order)
                   .WithMany(order => order.OrderHistories)
                   .HasForeignKey(orderHistory => orderHistory.OrderId);
            builder.Property(orderHistory => orderHistory.OrderId).IsRequired();

            builder.HasOne(orderHistory => orderHistory.OrderHistoryMethod)
                   .WithMany()
                   .HasForeignKey(orderHistory => orderHistory.OrderHistoryMethodId);
            builder.Property(orderHistory => orderHistory.OrderHistoryMethodId).IsRequired();
            builder.Property(orderHistory => orderHistory.Description).HasMaxLength(1000).IsRequired(false);
            builder.Property(orderHistory => orderHistory.Ts).HasColumnType("DATETIME").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
