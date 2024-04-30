using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var messages = await _userMessageService.GetAllMessageAsync();
            if (messages == null)
            {
                return NotFound();
            }
            return Ok(messages);
        }
        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetMessageSendbox(string id)
        {
            var values = await _userMessageService.GetSendboxMessageAsync(id);
            return Ok(values);
        }
        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetMessageInbox(string id)
        {
            var values = await _userMessageService.GetInboxMessageAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto request)
        {
            await _userMessageService.CreateMessageAsync(request);
            return Ok("Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            _userMessageService.DeleteMessageAsync(id);
            return Ok("Başarıyla Silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto request)
        {
            await _userMessageService.UpdateMessageAsync(request);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
