using Microsoft.EntityFrameworkCore;
using ExpressDelivery.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressDelivery.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string wireMockUrl = configuration.GetSection("WireMockSettings")["WireMockUrl"];
            bool isSQLiteProDbProvifer = Convert.ToBoolean(configuration["IsSQLiteProDbProvifer"]);

            services.AddDbContext<ExpressDeliveryDbContext>(options =>
            {
                //TODO: переделать выбор БД
                if (isSQLiteProDbProvifer)
                {
                    var connectionString = configuration["DbConnectionSQLlite"];
                    options.UseSqlite(connectionString);
                }
                else
                {
                    var connectionString = configuration["DbConnectionPostgreSQL"];
                    options.UseNpgsql(connectionString);
                }
                    
            });
            services.AddScoped<IExpressDeliveryDbContext>(provider => provider.GetService<ExpressDeliveryDbContext>());

            return services;
        }
    }
}
