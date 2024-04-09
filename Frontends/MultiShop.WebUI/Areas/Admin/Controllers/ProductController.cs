using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";

            var products = await _productService.GetProductAllAsync();
            return View(products);
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7022/api/Product");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            //    return View(values);
            //}

        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Yeni Ürün Girişi";
            ViewBag.v0 = "Ürün İşlemleri";

            var values = await _categoryService.GetCategoryAllAsync();
            List<SelectListItem> categories = (from category in values
                                               select new SelectListItem
                                               {
                                                   Text = category.CategoryName,
                                                   Value = category.CategoryID
                                               }).ToList();
            ViewBag.categoryList = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto request)
        {
            await _productService.CreateProductAsync(request);
            return RedirectToAction(nameof(ProductController.ProductListWithCategory), new { area = "Admin" });

        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(ProductController.ProductListWithCategory), new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Düzenle";
            ViewBag.v0 = "Ürün İşlemleri";


            var values = await _categoryService.GetCategoryAllAsync();
            List<SelectListItem> categories = (from category in values
                                               select new SelectListItem
                                               {
                                                   Text = category.CategoryName,
                                                   Value = category.CategoryID
                                               }).ToList();
            ViewBag.categoryList = categories;

            var product = await _productService.GetByIdProductAsync(id);

            return View(new UpdateProductDto
            {
                CategoryID = product.CategoryID,
                ProductDescription = product.ProductDescription,
                ProductID = product.ProductID,
                ProductImageUrl = product.ProductImageUrl,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto request)
        {
            await _productService.UpdateProductAsync(request);
            return RedirectToAction(nameof(ProductController.ProductListWithCategory), new { area = "Admin" });
        }

        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";
            var products = await _productService.GetProductsWithCategoryAsync();
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7022/api/Product/ProductListWithCategory");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            return View(products);
        }

    }
}
