using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class ExecutorStatusConfiguration : IEntityTypeConfiguration<ExecutorStatus>
    {
        public void Configure(EntityTypeBuilder<ExecutorStatus> builder)
        {
            builder.ToTable("ExecutorStatus");
            builder.HasKey(executorStatus => executorStatus.Id);
            builder.HasIndex(executorStatus => executorStatus.Id).IsUnique();
            builder.Property(executorStatus => executorStatus.Id).HasColumnName("Id");
            builder.Property(executorStatus => executorStatus.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(executorStatus => executorStatus.Actual).HasColumnName("Actual").IsRequired();
            builder.Property(executorStatus => executorStatus.Ts).HasColumnName("TS").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
