using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MultiShop.Order.Application.ServiceExtension
{
    public static class ServiceRegistiration
    {
        public static void ConfigureRegistiration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
