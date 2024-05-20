using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CommentServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatistics;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatistics;
using MultiShop.WebUI.Services.StatisticServices.MessageStatistics;
using MultiShop.WebUI.Services.StatisticServices.UserStatistics;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticsService _userStatisticsService;
        private readonly ICommentService _commentService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticsController(ICatalogStatisticService catalogStatisticService, IUserStatisticsService userStatisticsService, ICommentService commentService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticsService = userStatisticsService;
            _commentService = commentService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.brandCount = await _catalogStatisticService.GetBrandCountAsync();
            ViewBag.categoryCount = await _catalogStatisticService.GetCategoryCountAsync();
            ViewBag.getMaxPriceProductName = await _catalogStatisticService.GetMaxPriceProductNameAsync();
            ViewBag.getMinPriceProductName = await _catalogStatisticService.GetMinPriceProductNameAsync();
            ViewBag.productCount = await _catalogStatisticService.GetProductCountAsync();
            ViewBag.userCount = await _userStatisticsService.GetUserCount();
            ViewBag.totalCommentCount = await _commentService.GetTotalCommentCount();
            ViewBag.activeCommentCount = await _commentService.GetActiveCommentCount();
            ViewBag.passiveCommentCount = await _commentService.GetPassiveCommentCount();
            ViewBag.discountCouponCount = await _discountStatisticService.GetDiscountCouponCountAsync();
            ViewBag.messageCount = await _messageStatisticService.GetTotalMessageCount();
            return View();
        }
    }
}
