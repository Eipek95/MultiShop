using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductDetailFeatureComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var result = await _productService.GetByIdProductAsync(productId);
            return View(new UpdateProductDto
            {
                CategoryID = result.CategoryID,
                ProductID = result.ProductID,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                ProductPrice = result.ProductPrice,
                ProductImageUrl = result.ProductImageUrl
            });

        }
    }
}
