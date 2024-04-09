using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("brand", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("brand?id=" + id);
        }

        public async Task<ResultBrandGetByIdDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("brand/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<ResultBrandGetByIdDto>();
            return values;
        }

        public async Task<List<ResultBrandDto>> GetBrandAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("brand");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
            return values;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brand", updateBrandDto);
        }
    }
}
