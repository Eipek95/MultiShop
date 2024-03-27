using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderDetailResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}
