using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklifler ve Günün İndirim Listesi";
            ViewBag.v0 = "Özel Teklif İşlemleri";

            var result = await _specialOfferService.GetSpecialOfferAllAsync();
            return View(result);
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

            await _specialOfferService.CreateSpecialOfferAsync(request);
            return RedirectToAction(nameof(SpecialOfferController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction(nameof(SpecialOfferController.Index), new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklifler ve Günün İndirim Düzenle";
            ViewBag.v0 = "Özel Teklifler ve Günün İndirim İşlemleri";


            var result = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(new UpdateSpecialOfferDto
            {
                SpecialOfferId = result.SpecialOfferId,
                ImageUrl = result.ImageUrl,
                SubTitle = result.SubTitle,
                Title = result.Title
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto request)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(request);
            return RedirectToAction(nameof(SpecialOfferController.Index), new { area = "Admin" });
        }
    }
}
