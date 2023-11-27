using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class OrderHistoryMethodConfiguration : IEntityTypeConfiguration<OrderHistoryMethod>
    {
        public void Configure(EntityTypeBuilder<OrderHistoryMethod> builder)
        {
            builder.ToTable("OrderHistoryMethod");
            builder.HasKey(orderHistoryMethod => orderHistoryMethod.Id);
            builder.HasIndex(orderHistoryMethod => orderHistoryMethod.Id).IsUnique();
            builder.Property(orderHistoryMethod => orderHistoryMethod.Id).HasColumnName("Id");
            builder.Property(orderHistoryMethod => orderHistoryMethod.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(orderHistoryMethod => orderHistoryMethod.Code).HasColumnName("Code").IsRequired().HasMaxLength(20);
            builder.Property(orderHistoryMethod => orderHistoryMethod.IsActual).HasColumnName("IsActual").IsRequired();
            builder.Property(orderHistoryMethod => orderHistoryMethod.Ts).HasColumnName("TS").HasColumnType("DATETIME").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
