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
            builder.HasKey(executor => executor.Id);
            builder.HasIndex(executor => executor.Id).IsUnique();
            builder.Property(executor => executor.Id).HasColumnName("Id");
            builder.HasOne(executor => executor.ExecutorStatus)
                   .WithMany()
                   .HasForeignKey(executor => executor.ExecutorStatusId);
            builder.Property(executor => executor.ExecutorStatusId).HasColumnName("ExecutorStatus_Id").IsRequired();
            builder.Property(executor => executor.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(executor => executor.Description).HasColumnName("Description").HasMaxLength(1000);
            builder.Property(executor => executor.Ts).HasColumnName("TS").HasColumnType("DATETIME").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
