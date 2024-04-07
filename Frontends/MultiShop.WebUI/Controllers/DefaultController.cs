using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var user = User.Claims;
            int x = 0;
            return View();
        }
    }
}
