using Microsoft.OpenApi.Models;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.ServiceExtension;
using MultiShop.Order.Persistance.Context;
using MultiShop.Order.Persistance.Repository;

namespace MultShop.Order.WebApi.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<OrderContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IOrderingRepository), typeof(OrderingRepository));
            services.ConfigureRegistiration(configuration);//application katmanı içinde

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MultiShop Order API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Enter your token in the text input below. Bearer prefix will be added automatically.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                  {
                      {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                          new string[]{}
                      }
                  });
            });
        }
    }
}
