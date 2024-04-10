using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Anasayfa";
            ViewBag.Directory3 = "Ürün Listesi";
            return View();
        }
    }
}
