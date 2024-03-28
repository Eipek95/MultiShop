using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            //await _repository.CreateAsync(new OrderDetail
            //{
            //    OrderingId = request.OrderingId,
            //    ProductAmount = request.ProductAmount,
            //    ProductName = request.ProductName,
            //    ProductPrice = request.ProductPrice,
            //    ProductTotalPrice = request.ProductTotalPrice,
            //    ProductId = request.ProductId
            //});

            await _repository.CreateAsync(_mapper.Map<OrderDetail>(request));
        }
    }
}
