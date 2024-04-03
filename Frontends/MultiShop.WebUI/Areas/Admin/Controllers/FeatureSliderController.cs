using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Listesi";
            ViewBag.v0 = "Öne Çıkan İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7022/api/FeatureSlider");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Yeni Öne Çıkan Girişi";
            ViewBag.v0 = "Öne Çıkan İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto request)
        {
            request.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7022/api/FeatureSlider", stringContent);
            return RedirectToAction(nameof(FeatureSliderController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7022/api/FeatureSlider?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(FeatureSliderController.Index), new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Düzenle";
            ViewBag.v0 = "Öne Çıkan İşlemleri";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7022/api/FeatureSlider/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7022/api/FeatureSlider", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(FeatureSliderController.Index), new { area = "Admin" });
            }
            return RedirectToAction(nameof(FeatureSliderController.UpdateFeatureSlider), new { id = request.FeatureSliderID });
        }
    }
}
