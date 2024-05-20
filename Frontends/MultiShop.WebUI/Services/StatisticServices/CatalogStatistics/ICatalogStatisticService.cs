namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatistics
{
    public interface ICatalogStatisticService
    {
        Task<long> GetProductCountAsync();
        Task<long> GetCategoryCountAsync();
        Task<long> GetBrandCountAsync();
        Task<decimal> GetProductAvgPriceAsync();
        Task<string> GetMaxPriceProductNameAsync();
        Task<string> GetMinPriceProductNameAsync();
    }
}
