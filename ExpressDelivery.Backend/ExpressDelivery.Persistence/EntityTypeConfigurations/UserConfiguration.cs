using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Domain
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.Id);
            builder.Property(user => user.Name).IsRequired().HasMaxLength(50);
            builder.Property(user => user.Description).HasMaxLength(500);
            builder.Property(user => user.Ts).HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
