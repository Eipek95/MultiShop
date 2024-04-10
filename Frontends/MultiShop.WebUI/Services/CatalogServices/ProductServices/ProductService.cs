using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("product?id=" + id);
        }

        public async Task<ResultProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"product/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<ResultProductDto>();
            return value;
        }

        public async Task<List<ResultProductDto>> GetProductAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("product");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductDto>>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("product/productlistwithcategory");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var responseMessage = await _httpClient.GetAsync("product/productlistwithcategorybycategoryid?categoryId=" + categoryId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("product", updateProductDto);
        }
    }
}
