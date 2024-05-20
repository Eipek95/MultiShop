namespace MultiShop.WebUI.Services.StatisticServices.UserStatistics
{
    public interface IUserStatisticsService
    {
        Task<int> GetUserCount();
    }
}
