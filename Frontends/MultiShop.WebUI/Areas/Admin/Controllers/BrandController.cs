using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Listesi";
            ViewBag.v0 = "Marka İşlemleri";

            var result = await _brandService.GetBrandAllAsync();
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Yeni Marka Girişi";
            ViewBag.v0 = "Marka İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto request)
        {
            await _brandService.CreateBrandAsync(request);
            return RedirectToAction(nameof(BrandController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction(nameof(BrandController.Index), new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Düzenle";
            ViewBag.v0 = "Marka İşlemleri";


            var result = await _brandService.GetByIdBrandAsync(id);
            return View(new UpdateBrandDto
            {
                BrandID = result.BrandID,
                BrandName = result.BrandName,
                ImageUrl = result.ImageUrl,
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto request)
        {
            await _brandService.UpdateBrandAsync(request);
            return RedirectToAction(nameof(BrandController.Index), new { area = "Admin" });
        }
    }
}
