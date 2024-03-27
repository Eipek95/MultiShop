using AutoMapper;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateAddressCommand, Address>().ReverseMap();
            CreateMap<UpdateAddressCommand, Address>().ReverseMap();
            CreateMap<GetAddressByIdQueryResult, Address>().ReverseMap();
            CreateMap<GetAddressQueryResult, Address>().ReverseMap();

        }
    }
}
