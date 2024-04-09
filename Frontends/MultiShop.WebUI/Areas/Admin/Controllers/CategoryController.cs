using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;

        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.v0 = "Kategori İşlemleri";

            var values = await _categoryService.GetCategoryAllAsync();
            return View(values.OrderBy(x => x.CategoryName).ToList());

            //var client = _httpClientFactory.CreateClient();
            //var responsemessage = await client.GetAsync("https://localhost:7022/api/categories");
            //if (responsemessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responsemessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values?.OrderBy(x => x.CategoryName).ToList());
            //}
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            ViewBag.v0 = "Kategori İşlemleri";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto request)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(request);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7022/api/Categories", stringContent);
            await _categoryService.CreateCategoryAsync(request);
            return RedirectToAction(nameof(CategoryController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(CategoryController.Index), new { area = "Admin" });
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.DeleteAsync("https://localhost:7022/api/Categories?id=" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction(nameof(CategoryController.Index), new { area = "Admin" });
            //}
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Düzenle";
            ViewBag.v0 = "Kategori İşlemleri";
            var value = await _categoryService.GetByIdCategoryAsync(id);
            return View(new UpdateCategoryDto
            {
                CategoryID = value.CategoryID,
                CategoryName = value.CategoryName,
                ImageUrl = value.ImageUrl,
            });

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7022/api/Categories/" + id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
            //    return View(values);
            //}
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto request)
        {
            await _categoryService.UpdateCategoryAsync(new UpdateCategoryDto
            {
                CategoryID = request.CategoryID,
                ImageUrl = request.ImageUrl,
                CategoryName = request.CategoryName,
            });
            return RedirectToAction(nameof(CategoryController.Index), new { area = "Admin" });
            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(request);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PutAsync("https://localhost:7022/api/Categories", stringContent);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    return RedirectToAction(nameof(CategoryController.Index), new { area = "Admin" });
            //}
            //return RedirectToAction(nameof(CategoryController.UpdateCategory), new { id = request.CategoryID });
        }
    }
}
