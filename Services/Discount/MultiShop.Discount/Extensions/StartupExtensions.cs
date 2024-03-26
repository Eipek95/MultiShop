using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {


            services.AddTransient<DapperContext>();
            services.AddTransient<IDiscountService, DiscountService>();
        }
    }
}
