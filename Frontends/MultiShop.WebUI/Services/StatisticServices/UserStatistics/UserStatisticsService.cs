namespace MultiShop.WebUI.Services.StatisticServices.UserStatistics
{
    public class UserStatisticsService : IUserStatisticsService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetUserCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/Statistics/");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
