using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Listesi";
            ViewBag.v0 = "Hakkımızda İşlemleri";

            var result = await _aboutService.GetAboutAllAsync();
            return View(result);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Yeni Hakkımızda Girişi";
            ViewBag.v0 = "Hakkımızda İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto request)
        {
            await _aboutService.CreateAboutAsync(request);
            return RedirectToAction(nameof(AboutController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.v3 = "Hakkımızda Düzenle";
            ViewBag.v0 = "Hakkımızda İşlemleri";


            var result = await _aboutService.GetByIdAboutAsync(id);
            return View(new UpdateAboutDto
            {
                AboutID = result.AboutID,
                Address = result.Address,
                Description = result.Description,
                Email = result.Email,
                Phone = result.Phone
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto request)
        {
            await _aboutService.UpdateAboutAsync(request);
            return RedirectToAction(nameof(AboutController.Index), new { area = "Admin" });
        }
    }
}
