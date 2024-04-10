using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferDefaultComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklifler ve Günün İndirim Listesi";
            ViewBag.v0 = "Özel Teklif İşlemleri";

            var result = await _specialOfferService.GetSpecialOfferAllAsync();
            return View(result);
        }
    }
}
