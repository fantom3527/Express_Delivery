using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class ExecutorConfiguration : IEntityTypeConfiguration<Executor>
    {
        public void Configure(EntityTypeBuilder<Executor> builder)
        {
            builder.ToTable("Executor");
            builder.HasKey(city => city.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(city => city.Id).HasColumnName("Id");
            builder.HasOne(order => order.ExecutorStatus)
                   .WithMany(executorStatus => executorStatus.Executors)
                   .HasForeignKey(order => order.ExecutorStatusId);
            builder.Property(city => city.ExecutorStatusId).HasColumnName("ExecutorStatus_Id");
            builder.Property(city => city.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(city => city.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(city => city.Ts).HasColumnName("TS").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
