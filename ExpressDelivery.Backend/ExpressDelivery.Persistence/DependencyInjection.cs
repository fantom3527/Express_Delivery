using ExpressDelivery.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressDelivery.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IExpressDeliveryDbContext>(provider => provider.GetService<ExpressDeliveryDbContext>());

            return services;
        }
    }
}
