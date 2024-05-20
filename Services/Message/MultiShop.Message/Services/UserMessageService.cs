using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _messageContext.UserMessages.AddAsync(_mapper.Map<UserMessage>(createMessageDto));
            await _messageContext.SaveChangesAsync();
        }

        public Task DeleteMessageAsync(int id)
        {
            var values = _messageContext.UserMessages.Find(id);

            if (values != null)
            {
                _messageContext.UserMessages.Remove(values);
                _messageContext.SaveChanges();

                return Task.CompletedTask;
            }
            Exception ex = new Exception("İşlem başarısız oldu.");
            return Task.FromException(ex);
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.UserMessageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdMessageDto>(values);

        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.RecieverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task<int> GetTotalMessageCount()
        {
            var value = await _messageContext.UserMessages.CountAsync();
            return value;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            _messageContext.UserMessages.Update(_mapper.Map<UserMessage>(updateMessageDto));
            await _messageContext.SaveChangesAsync();
        }
    }
}
