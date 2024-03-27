using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            //await _repository.CreateAsync(new Address
            //{
            //    UserId = request.UserId,
            //    Detail = request.Detail,
            //    City = request.City,
            //    District = request.District,
            //});

            await _repository.CreateAsync(_mapper.Map<Address>(request));
        }
    }
}
