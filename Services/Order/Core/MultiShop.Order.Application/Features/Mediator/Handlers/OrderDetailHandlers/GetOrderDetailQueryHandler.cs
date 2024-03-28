using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetOrderDetailQueryResult>>(values);
            //return values.Select(x => new GetOrderDetailQueryResult
            //{
            //    OrderDetailId = x.OrderDetailId,
            //    OrderingId = x.OrderingId,
            //    ProductAmount = x.ProductAmount,
            //    ProductId = x.ProductId,
            //    ProductName = x.ProductName,
            //    ProductPrice = x.ProductPrice,
            //    ProductTotalPrice = x.ProductTotalPrice,
            //}).ToList();
        }
    }
}
