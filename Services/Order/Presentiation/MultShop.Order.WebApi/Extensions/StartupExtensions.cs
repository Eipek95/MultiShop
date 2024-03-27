using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistance.Repository;

namespace MultShop.Order.WebApi.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(StartupExtensions).Assembly));
        }
    }
}
