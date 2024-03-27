using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderDetailResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery : IRequest<List<GetOrderDetailQueryResult>>
    {
    }
}
