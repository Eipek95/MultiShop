using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingId = request.OrderingId,
                ProductAmount = request.ProductAmount,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductTotalPrice = request.ProductTotalPrice,
                ProductId = request.ProductId
            });
        }
    }
}
