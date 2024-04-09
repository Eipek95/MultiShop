using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Alan Alanlar";
            ViewBag.v3 = "Öne Çıkan Alan Listesi";
            ViewBag.v0 = "Öne Çıkan Alan İşlemleri";

            var values = await _featureService.GetFeatureAllAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = "Yeni Öne Çıkan Alan Girişi";
            ViewBag.v0 = "Öne Çıkan Alan İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto request)
        {
            await _featureService.CreateFeatureAsync(request);
            return RedirectToAction(nameof(FeatureController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction(nameof(FeatureController.Index), new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = "Öne Çıkan Alan Düzenle";
            ViewBag.v0 = "Öne Çıkan Alan İşlemleri";


            var values = await _featureService.GetByIdFeatureAsync(id);
            return View(new UpdateFeatureDto
            {
                FeatureID = values.FeatureID,
                Icon = values.Icon,
                Title = values.Title,
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto request)
        {
            await _featureService.UpdateFeatureAsync(request);
            return RedirectToAction(nameof(FeatureController.Index), new { area = "Admin" });
        }
    }
}
