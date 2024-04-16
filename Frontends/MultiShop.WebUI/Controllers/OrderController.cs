using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            ViewBag.directory1 = "Multishop";
            ViewBag.directory2 = "Siparişler";
            ViewBag.directory3 = "Sipariş İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAddress([FromBody] CreateOrderAddressDto request)
        {
            var values = await _userService.GetUserInfo();
            request.UserId = values.Id;
            await _orderAddressService.CreateOrderAddressAsync(request);
            return RedirectToAction(nameof(OrderController.Index), "Order");
        }
    }
}
