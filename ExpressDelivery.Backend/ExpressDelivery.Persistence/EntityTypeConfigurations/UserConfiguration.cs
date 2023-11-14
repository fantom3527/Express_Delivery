using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpressDelivery.Domain
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.Id).HasColumnName("Id");
            builder.Property(user => user.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(user => user.Description).HasColumnName("Description").HasMaxLength(500);
            builder.Property(user => user.Ts).HasColumnName("TS").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
