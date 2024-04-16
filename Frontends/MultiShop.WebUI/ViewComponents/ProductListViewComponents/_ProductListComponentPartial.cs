using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryId, int pageNumber = 1, int pageSize = 1)
        {
            var result = await _productService.GetProductsWithCategoryByCategoryIdAsync(categoryId);
            var totalItems = result.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var values = result.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            return View(values);
        }
    }
}
