using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos.TokenDtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TokenController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> GetToken(GetTokenDto request)
        {
            var tokenData = new Dictionary<string, string>
            {
                { "grant_type", request.grant_type },
                { "client_id", request.client_id },
                { "client_secret", request.client_secret },
            };

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsync("http://localhost:5001/connect/token", new FormUrlEncodedContent(tokenData));

            var responseContent = await response.Content.ReadAsStringAsync();


            // Başarılı ise cevabı geri döndür
            if (response.IsSuccessStatusCode)
            {
                return Ok(JsonConvert.DeserializeObject<ResultTokenDto>(responseContent));
            }

            return BadRequest(responseContent);// Başarısız ise hata mesajını geri döndür
        }
    }
}

