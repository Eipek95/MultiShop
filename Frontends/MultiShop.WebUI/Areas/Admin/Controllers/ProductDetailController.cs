using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Açıklama ve Bilgi Düzenle";
            ViewBag.v0 = "Ürün İşlemleri";


            var result = await _productDetailService.GetByIdProductDetailAsync(id);
            return View(new UpdateProductDetailDto
            {
                ProductInformation = result.ProductInformation,
                ProductId = result.ProductId,
                ProductDescription = result.ProductDescription,
                ProductDetailID = result.ProductDetailID
            });

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7022/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
            //    return View(values);
            //}
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto request)
        {
            await _productDetailService.UpdateProductDetailAsync(request);
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(request);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:7022/api/ProductDetails", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //}
            //return RedirectToAction(nameof(ProductDetailController.UpdateProductDetail), new { id = request.ProductId });
            return RedirectToAction(nameof(ProductController.ProductListWithCategory), "Product", new { area = "Admin" });
        }
    }
}
