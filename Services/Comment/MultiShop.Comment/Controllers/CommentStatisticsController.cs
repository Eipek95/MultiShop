using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;

namespace MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentStatisticsController : ControllerBase
    {

        private readonly CommentContext _context;

        public CommentStatisticsController(CommentContext context)
        {
            _context = context;
        }
        [HttpGet("GetTotalCommentCount")]
        public async Task<IActionResult> GetTotalCommentCount()
        {
            var values = await _context.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
