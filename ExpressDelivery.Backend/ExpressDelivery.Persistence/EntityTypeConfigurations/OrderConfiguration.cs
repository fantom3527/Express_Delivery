using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Domain
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(order => order.Id);
            builder.HasIndex(order => order.Id).IsUnique();
            builder.Property(order => order.Id).HasColumnName("Id");
            builder.HasOne(order => order.OrderStatus)
                   .WithMany(orderStatus => orderStatus.Orders)
                   .HasForeignKey(order => order.OrderStatusId);
            builder.Property(order => order.OrderStatusId).HasColumnName("OrderStatus_Id");
            builder.HasOne(order => order.Executor)
                   .WithMany(executor => executor.Orders)
                   .HasForeignKey(order => order.ExecutorId);
            builder.Property(order => order.ExecutorId).HasColumnName("Executor_Id");
            builder.HasOne(order => order.User)
                   .WithMany(user => user.Orders)
                   .HasForeignKey(order => order.UserId);
            builder.Property(order => order.UserId).HasColumnName("User_Id");
            builder.Property(order => order.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(order => order.ReceiptAddress).HasColumnName("ReceiptAddress").IsRequired().HasMaxLength(100);
            builder.Property(order => order.DeliveryAddress).HasColumnName("DeliveryAddress").IsRequired().HasMaxLength(100);
            builder.Property(order => order.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(order => order.ReceiptTime).HasColumnName("ReceiptTime").IsRequired();
            builder.Property(order => order.DeliveryTime).HasColumnName("DeliveryTime");
            builder.Property(order => order.Ts).HasColumnName("TS").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
