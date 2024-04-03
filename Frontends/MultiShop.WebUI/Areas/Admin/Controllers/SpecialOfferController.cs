using Microsoft.AspNetCore.Mvc;

using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklifler ve Günün İndirim Listesi";
            ViewBag.v0 = "Özel Teklif İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7022/api/SpecialOffer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Yeni Özel Teklifler ve Günün İndirim Girişi";
            ViewBag.v0 = "Özel Teklifler İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7022/api/SpecialOffer", stringContent);
            return RedirectToAction(nameof(SpecialOfferController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7022/api/SpecialOffer?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(SpecialOfferController.Index), new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklifler ve Günün İndirim Düzenle";
            ViewBag.v0 = "Özel Teklifler ve Günün İndirim İşlemleri";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7022/api/SpecialOffer/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7022/api/SpecialOffer", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(SpecialOfferController.Index), new { area = "Admin" });
            }
            return RedirectToAction(nameof(SpecialOfferController.UpdateSpecialOffer), new { id = request.SpecialOfferId });
        }
    }
}
