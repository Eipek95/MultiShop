using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görsel Düzenle";
            ViewBag.v0 = "Ürün Görsel İşlemleri";


            var result = await _productImageService.GetByIdProductImageAsync(id);
            return View(new UpdateProductImageDto
            {
                ProductImagesID = result.ProductImagesID,
                ProductID = result.ProductID,
                Image1 = result.Image1,
                Image2 = result.Image2,
                Image3 = result.Image3
            });
        }

        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto request)
        {
            await _productImageService.UpdateProductImageAsync(request);
            return RedirectToAction(nameof(ProductController.ProductListWithCategory), "Product", new { area = "Admin" });
        }
    }

}

