using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _CategoriesDefaultComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            var products = await _productService.GetProductsWithCategoryAsync();

            var categoryProduct = products.GroupBy(p => p.Category.CategoryName)
                                          .Select(g => new CategoryProduct
                                          {
                                              CategoryName = g.Key,
                                              Count = g.Count(),
                                              CategoryID = g.FirstOrDefault()?.Category.CategoryID,
                                              ImageUrl = g.FirstOrDefault()?.Category.ImageUrl
                                          })
                                          .ToList();

            return View(categoryProduct);
        }
    }
}

