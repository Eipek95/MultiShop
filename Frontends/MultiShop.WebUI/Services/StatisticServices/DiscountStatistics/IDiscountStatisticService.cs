namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatistics
{
    public interface IDiscountStatisticService
    {
        Task<int> GetDiscountCouponCountAsync();
    }
}
