using AutoMapper;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultMessageDto, UserMessage>().ReverseMap();
            CreateMap<UpdateMessageDto, UserMessage>().ReverseMap();
            CreateMap<CreateMessageDto, UserMessage>().ReverseMap();
            CreateMap<GetByIdMessageDto, UserMessage>().ReverseMap();
            CreateMap<ResultInboxMessageDto, UserMessage>().ReverseMap();
            CreateMap<ResultSendboxMessageDto, UserMessage>().ReverseMap();
        }
    }
}
