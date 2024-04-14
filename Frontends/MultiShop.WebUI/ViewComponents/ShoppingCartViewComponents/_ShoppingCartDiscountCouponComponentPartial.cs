using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartDiscountCouponComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? couponCode)
        {

            var basket = await _basketService.GetBasket();


            var result = new BasketCouponViewModel
            {
                BasketTotalDto = basket,
            };
            return View(result);
        }
    }
}
