using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }

        [HttpGet]//bu kodları ben kendim yaparak login işlemi
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto request)
        {

            var tokenData = new Dictionary<string, string>
            {
                { "client_id", "MultiShopManagerId" },
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


                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction(nameof(DefaultController.Index), "Default");
                    }
                }
            }
            return View();
        }


        //[HttpGet]//bu kod ise identityserver4 için gerekli ve daha güvenli bir şekilde yapılan login işlemi
        //public IActionResult SignIn()
        //{
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.Username = "eipek3";
            signInDto.Password = "pASSWORD123*";
            await _identityService.SignIn(signInDto);
            return RedirectToAction(nameof(DefaultController.Index), "Default");
        }
    }
}
