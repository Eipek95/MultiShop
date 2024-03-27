using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderDetailId);
            values.OrderingId = request.OrderingId;
            values.ProductId = request.ProductId;
            values.ProductName = request.ProductName;
            values.ProductPrice = request.ProductPrice;
            values.ProductTotalPrice = request.ProductTotalPrice;
            values.ProductAmount = request.ProductAmount;
            await _repository.UpdateAsync(values);
        }
    }
}
