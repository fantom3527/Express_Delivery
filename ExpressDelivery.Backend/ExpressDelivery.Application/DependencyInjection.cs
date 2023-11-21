using ExpressDelivery.Application.Managers;
using ExpressDelivery.Application.Managers.Interfaces;
using ExpressDelivery.Application.Repositories;
using ExpressDelivery.Application.Repositories.Interfaces;
using ExpressDelivery.Application.Services;
using ExpressDelivery.Application.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExpressDelivery.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IExecutorRepository, ExecutorRepository>();
            services.AddScoped<IExecutorStatusRepository, ExecutorStatusRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IOrderHistoryRepository, OrderHistoryRepository>();
            services.AddScoped<IOrderHistoryMethodRepository, OrderHistoryMethodRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddScoped<IExecutorService, ExecutorService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            return services;
        }
    }
}
