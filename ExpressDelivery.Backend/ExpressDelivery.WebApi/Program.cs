using ExpressDelivery.Persistence;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ExpressDelivery.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                                      .WriteTo.File("LogFiles/ExpressDelivery-.txt", rollingInterval: RollingInterval.Day)
                                      .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ExpressDeliveryDbContext>();
                    DbInitializer.Initialize(context);
                    serviceProvider.GetRequiredService<ExpressDeliveryDbContext>().Database.Migrate();
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "An error occurred while app initialization");
                }


            }

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ExpressDeliveryDbContext>();
                    context.Database.Migrate();
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "An error occurred while applying migrations");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}