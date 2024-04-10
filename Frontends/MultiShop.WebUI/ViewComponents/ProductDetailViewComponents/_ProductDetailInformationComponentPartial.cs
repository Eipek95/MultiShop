using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var result = await _productDetailService.GetByIdProductDetailAsync(productId);
            return View(new UpdateProductDetailDto
            {
                ProductDescription = result.ProductDescription,
                ProductDetailID = result.ProductDetailID,
                ProductId = result.ProductId,
                ProductInformation = result.ProductInformation
            });
        }
    }
}
