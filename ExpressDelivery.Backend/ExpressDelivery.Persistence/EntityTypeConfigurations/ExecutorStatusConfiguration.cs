using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Persistence.EntityTypeConfigurations
{
    internal class ExecutorStatusConfiguration : IEntityTypeConfiguration<ExecutorStatus>
    {
        public void Configure(EntityTypeBuilder<ExecutorStatus> builder)
        {
            builder.HasKey(executorStatus => executorStatus.Id);
            builder.HasIndex(executorStatus => executorStatus.Id).IsUnique();
            builder.Property(executorStatus => executorStatus.Id);
            builder.Property(executorStatus => executorStatus.Name).IsRequired().HasMaxLength(50);
            builder.Property(executorStatus => executorStatus.Code).IsRequired().HasMaxLength(20);
            builder.Property(executorStatus => executorStatus.IsActual).IsRequired();
            builder.Property(executorStatus => executorStatus.Ts).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
