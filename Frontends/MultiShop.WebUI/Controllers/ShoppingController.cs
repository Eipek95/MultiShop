using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    [Authorize]
    public class ShoppingController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public IActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Anasayfa";
            ViewBag.Directory3 = "Sepetim";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBasketItem(string productId, int quantity = 1)
        {

            var currentUserId = User.Claims.FirstOrDefault(x => x.Type == "sub");

            if (currentUserId?.Value == null)
            {
                return Json(false);
            }

            var values = await _productService.GetByIdProductAsync(productId);
            var items = new BasketItemDto
            {
                Price = values.ProductPrice,
                ProductId = values.ProductID,
                ProductName = values.ProductName,
                Quantity = quantity,
                ProductImageUrl = values.ProductImageUrl,
            };

            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }
        [HttpPost]

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItem(productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ApplyDiscount(DiscountApplyInput discountApplyInput)
        {
            var status = await _basketService.ApplyDiscount(discountApplyInput.Code);
            TempData["discountStatus"] = status;
            return RedirectToAction(nameof(ShoppingController.Index));
        }

        public async Task<IActionResult> CancelApplyDiscount()
        {
            var status = await _basketService.CancelApplyDiscount();
            return RedirectToAction(nameof(ShoppingController.Index));
        }
    }
}
