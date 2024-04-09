﻿using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDto>("about", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("about?id=" + id);
        }

        public async Task<ResultAboutGetByIdDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("about/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<ResultAboutGetByIdDto>();
            return values;
        }

        public async Task<List<ResultAboutDto>> GetAboutAllAsync()
        {
            var responseMessage = await _httpClient.GetAsync("about");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
            return values;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDto>("about", updateAboutDto);
        }
    }
}
