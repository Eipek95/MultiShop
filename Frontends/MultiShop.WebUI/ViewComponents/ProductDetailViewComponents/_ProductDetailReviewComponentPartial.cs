using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var result = await _commentService.CommentListByProductIdAsync(productId);
            ViewBag.ProductId = productId;
            return View(result);
        }
    }
}
