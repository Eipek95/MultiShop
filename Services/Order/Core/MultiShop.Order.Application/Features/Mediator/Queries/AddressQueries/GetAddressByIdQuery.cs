using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.AddressResults;

namespace MultiShop.Order.Application.Features.Mediator.Queries.AddressQueries
{
    public class GetAddressByIdQuery : IRequest<GetAddressByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
