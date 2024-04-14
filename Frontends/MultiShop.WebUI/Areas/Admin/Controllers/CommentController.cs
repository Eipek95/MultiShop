using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";

            var result = await _commentService.GetCommentAllAsync();
            return View(result);
        }


        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Düzenleme";
            ViewBag.v0 = "Yorum İşlemleri";


            var result = await _commentService.GetByIdCommentAsync(id);
            return View(new UpdateCommentDto
            {
                UserCommentId = result.UserCommentId,
                CommentDetail = result.CommentDetail,
                CreatedDate = result.CreatedDate,
                Email = result.Email,
                ImageUrl = result.ImageUrl,
                NameSurname = result.NameSurname,
                ProductId = result.ProductId,
                Rating = result.Rating,
                Status = result.Status
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto request)
        {

            await _commentService.UpdateCommentAsync(request);
            return RedirectToAction(nameof(CommentController.Index), new { area = "Admin" });
        }
    }
}
