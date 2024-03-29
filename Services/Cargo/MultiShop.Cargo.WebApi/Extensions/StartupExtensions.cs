using Microsoft.OpenApi.Models;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccesss.Abstract;
using MultiShop.Cargo.DataAccesss.Concrete;
using MultiShop.Cargo.DataAccesss.EntityFramework;
using System.Reflection;

namespace MultiShop.Cargo.WebApi.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CargoContext>();
            services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();

            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
            services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();

            services.AddScoped<ICargoDetailService, CargoDetailManager>();
            services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();

            services.AddScoped<ICargoOperationService, CargoOperationManager>();
            services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MultiShop Catalog API", Version = "v1" });

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
