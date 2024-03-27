using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.ServiceExtension;
using MultiShop.Order.Persistance.Repository;

namespace MultShop.Order.WebApi.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.ConfigureRegistiration(configuration);//application katmanı içinde
        }
    }
}
