using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpGet("InitializeCart")]
        public async Task<IActionResult> InitializeCart()
        {
            await _basketService.InitializeCart(_loginService.GetUserId);
            return Ok("Başarıyla Oluşturuldu");
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto request)
        {
            request.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(request);
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Başarıyla Silindi");
        }
    }
}
