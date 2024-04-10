using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var values = _context.UserComments.Find(id);
            return Ok(values);
        }
        [HttpGet("GetCommentByProductId")]
        public async Task<IActionResult> GetCommentByProductId(string productId)
        {
            var values = _context.UserComments.Where(x => x.ProductId == productId).ToList();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            _context.SaveChanges();
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UserComment userComment)
        {
            _context.UserComments.Update(userComment);
            _context.SaveChanges();
            return Ok("Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var value = _context.UserComments.Find(id);
            _context.UserComments.Remove(value);
            _context.SaveChanges();
            return Ok("Başarıyla Silindi");
        }
    }
}
