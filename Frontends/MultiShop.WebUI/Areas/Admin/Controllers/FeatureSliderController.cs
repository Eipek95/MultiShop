using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Listesi";
            ViewBag.v0 = "Öne Çıkan İşlemleri";

            var values = await _featureSliderService.GetFeatureSliderAllAsync();
            return View(values);
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
            await _featureSliderService.CreateFeatureSliderAsync(request);
            return RedirectToAction(nameof(FeatureSliderController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction(nameof(FeatureSliderController.Index), new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Düzenle";
            ViewBag.v0 = "Öne Çıkan İşlemleri";

            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(new UpdateFeatureSliderDto
            {
                FeatureSliderID = values.FeatureSliderID,
                Description = values.Description,
                Imageurl = values.Imageurl,
                Status = values.Status,
                Title = values.Title
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto request)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(request);
            return RedirectToAction(nameof(FeatureSliderController.Index), new { area = "Admin" });
        }
    }
}
