using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";

            var values = await _offerDiscountService.GetOfferDiscountAllAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "Yeni İndirim Teklif Girişi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto request)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(request);
            return RedirectToAction(nameof(OfferDiscountController.Index), new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction(nameof(OfferDiscountController.Index), new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Düzenle";
            ViewBag.v0 = "İndirim Teklif İşlemleri";


            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(new UpdateOfferDiscountDto
            {
                OfferDiscountId = values.OfferDiscountId,
                ButtonTitle = values.ButtonTitle,
                ImageUrl = values.ImageUrl,
                SubTitle = values.SubTitle,
                Title = values.Title
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto request)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(request);
            return RedirectToAction(nameof(OfferDiscountController.Index), new { area = "Admin" });
        }
    }
}
