using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Domain
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.HasIndex(order => order.Id).IsUnique();
            builder.Property(order => order.Id);
            builder.HasOne(order => order.OrderStatus)
                   .WithMany()
                   .HasForeignKey(order => order.OrderStatusId);
            builder.Property(order => order.OrderStatusId).IsRequired();
            builder.HasOne(order => order.Executor)
                   .WithMany(executor => executor.Orders)
                   .HasForeignKey(order => order.ExecutorId);
            builder.Property(order => order.ExecutorId).IsRequired(false);
            builder.HasOne(order => order.User)
                   .WithMany(user => user.Orders)
                   .HasForeignKey(order => order.UserId);
            builder.Property(order => order.UserId);
            builder.Property(order => order.Name).IsRequired().HasMaxLength(50);
            builder.Property(order => order.ReceiptAddress).IsRequired().HasMaxLength(100);
            builder.Property(order => order.DeliveryAddress).IsRequired().HasMaxLength(100);
            builder.Property(order => order.Description).HasMaxLength(1000);
            builder.Property(order => order.ReceiptTime).IsRequired();
            builder.Property(order => order.DeliveryTime).IsRequired();
            builder.Property(order => order.Ts).HasColumnType("DATETIME").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
