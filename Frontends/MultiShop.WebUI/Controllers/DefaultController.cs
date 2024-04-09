using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ICategoryService _categoryService;

        public DefaultController(ILoginService loginService, ICategoryService categoryService)
        {
            _loginService = loginService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var category = await _categoryService.GetCategoryAllAsync();

            return View();
        }
    }
}
