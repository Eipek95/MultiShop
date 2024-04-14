using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;

        public ProductListController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.categoryId = id;
            ViewBag.Directory1 = "Anasayfa";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Ürün Listesi";
            return View();
        }

        public IActionResult ProductDetail(string productId)
        {
            ViewBag.Directory1 = "Anasayfa";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Ürün Detay";
            ViewBag.x = productId;
            return View();
        }

        [HttpPost]
        public async Task<bool> AddComment(CreateCommentDto request)
        {
            request.CreatedDate = DateTime.Now;
            request.ImageUrl = "https://yt3.ggpht.com/a/AATXAJyk2VmL7NqghohEuPMG3VqdQrP66-UTq98FIQ=s900-c-k-c0xffffffff-no-rj-mo";
            await _commentService.CreateCommentAsync(request);
            return true;
        }
    }
}
