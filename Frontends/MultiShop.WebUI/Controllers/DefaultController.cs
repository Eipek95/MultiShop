using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ILoginService _loginService;

        public DefaultController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _loginService.GetUserId;
            return View();
        }
    }
}
