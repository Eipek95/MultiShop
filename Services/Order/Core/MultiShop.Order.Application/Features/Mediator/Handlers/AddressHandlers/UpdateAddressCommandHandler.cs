using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AddressId);

            values.UserId = request.UserId;
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Email = request.Email;
            values.Phone = request.Phone;
            values.Country = request.Country;
            values.City = request.City;
            values.District = request.District;
            values.Detail1 = request.Detail1;
            values.Detail2 = request.Detail2;
            request.Description = request.Description;
            request.ZipCode = request.ZipCode;
            await _repository.UpdateAsync(values);
        }
    }
}
