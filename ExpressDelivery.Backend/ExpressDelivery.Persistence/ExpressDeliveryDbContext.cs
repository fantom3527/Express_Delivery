using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Domain;
using ExpressDelivery.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Persistence
{
    public class ExpressDeliveryDbContext : DbContext, IExpressDeliveryDbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Executor> Executor { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<ExecutorStatus> ExecutorStatus { get; set; }

        public ExpressDeliveryDbContext(DbContextOptions<ExpressDeliveryDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ExecutorConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ExecutorStatusConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
