using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("deneme amaçlı gönderildi");
            }
            else
            {
                return Ok("Kullanıcı Adı veya Şifre Hatalı");
            }
        }
    }
}
