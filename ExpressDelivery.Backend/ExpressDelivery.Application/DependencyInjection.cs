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
            services.AddScoped<IExecutorService, ExecutorService>();
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            return services;
        }
    }
}
