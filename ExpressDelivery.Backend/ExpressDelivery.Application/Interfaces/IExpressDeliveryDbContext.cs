﻿using ExpressDelivery.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpressDelivery.Application.Interfaces
{
    public interface IExpressDeliveryDbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<OrderHistoryMethod> OrderHistoryMethod { get; set; }
        public DbSet<Executor> Executor { get; set; }
        public DbSet<ExecutorStatus> ExecutorStatus { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<CargoType> CargoType { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
