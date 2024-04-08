using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto request)
        {

            var tokenData = new Dictionary<string, string>
            {
                { "client_id", "MultiShopVisitorId" },
                { "client_secret", "multishopsecret" },
                { "grant_type", "password" },
                { "username", request.Username.ToString() },
                { "password", request.Password.ToString()},
            };

            var httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:5001/connect/token", new FormUrlEncodedContent(tokenData));

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });


                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.access_token);
                    var claims = token.Claims.ToList();


                    if (tokenModel.access_token != null)
                    {
                        claims.Add(new Claim("multishoptoken", tokenModel.access_token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(tokenModel.expires_in),
                            IsPersistent = true
                        };

                        var deger = token.RawData;
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction(nameof(DefaultController.Index), "Default");
                    }
                }
            }
            return View();
        }
    }
}
