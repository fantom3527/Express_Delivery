using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ExpressDelivery.Application;
using ExpressDelivery.Application.Interfaces;
using ExpressDelivery.Persistence;
using ExpressDelivery.Application.Common.Mapping;
using Microsoft.EntityFrameworkCore;
using ExpressDelivery.WebApi.Middleware;

namespace ExpressDelivery.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IExpressDeliveryDbContext).Assembly));
            });

            services.AddDbContext<ExpressDeliveryDbContext>(options =>
            {
                var provider = Configuration.GetValue("provider", Provider.Sqlite.Name);

                options.UseSnakeCaseNamingConvention();

                if (provider == Provider.Sqlite.Name)
                {
                    options.UseSqlite(
                        Configuration.GetConnectionString(Provider.Sqlite.Name)!,
                        x => x.MigrationsAssembly(Provider.Sqlite.Assembly)
                    );
                }
                if (provider == Provider.PostgreSql.Name)
                {
                    options.UseNpgsql(
                        Configuration.GetConnectionString(Provider.PostgreSql.Name)!,
                        x => x.MigrationsAssembly(Provider.PostgreSql.Assembly)
                    );
                }
            });

            services.AddApplication();
            services.AddPersistence();
            services.AddControllers();

            // Для теста предоставим доступ для всех
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
       

            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            services.AddApiVersioning();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            // Задаем интерфейс сваггера по умолчанию.
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    config.RoutePrefix = string.Empty;
                }
            });

            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
