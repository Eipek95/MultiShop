using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(string id)
        {
            ViewBag.categoryId = id;
            return View();
        }

        public IActionResult ProductDetail(string productId)
        {
            ViewBag.x = productId;
            return View();
        }

        [HttpPost]
        public async Task<bool> AddComment(CreateCommentDto request)
        {
            request.CreatedDate = DateTime.Now;
            request.ImageUrl = "https://yt3.ggpht.com/a/AATXAJyk2VmL7NqghohEuPMG3VqdQrP66-UTq98FIQ=s900-c-k-c0xffffffff-no-rj-mo";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7136/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
