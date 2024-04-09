using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("feature", createFeatureDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("feature?id=" + id);
        }

        public async Task<ResultFeatureGetByIdDto> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("feature/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<ResultFeatureGetByIdDto>();
            return values;
        }

        public async Task<List<ResultFeatureDto>> GetFeatureAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("feature");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultFeatureDto>>();
            return values;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("feature", updateFeatureDto);
        }
    }
}
