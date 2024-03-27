using MediatR;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveOrderDetailCommand(int id)
        {
            Id = id;
        }
    }
}
