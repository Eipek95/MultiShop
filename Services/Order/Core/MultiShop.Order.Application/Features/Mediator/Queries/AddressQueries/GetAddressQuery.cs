using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries
{
    public class GetAddressQuery : IRequest<List<GetAddressQueryResult>>
    {
    }
}
