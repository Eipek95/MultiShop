using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7022/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Yeni Ürün Girişi";
            ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7022/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
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
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7022/api/Product", stringContent);
            return RedirectToAction(nameof(ProductController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7022/api/Product?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ProductController.Index), new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Düzenle";
            ViewBag.v0 = "Ürün İşlemleri";


            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("https://localhost:7022/api/Categories");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
            List<SelectListItem> categories = (from category in values2
                                               select new SelectListItem
                                               {
                                                   Text = category.CategoryName,
                                                   Value = category.CategoryID
                                               }).ToList();

            ViewBag.categoryList = categories;

            var responseMessage = await client.GetAsync("https://localhost:7022/api/Product/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7022/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ProductController.Index), new { area = "Admin" });
            }
            return RedirectToAction(nameof(ProductController.UpdateProduct), new { id = request.ProductID });
        }

        public async Task<IActionResult> ProductListWithCategory()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7022/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
