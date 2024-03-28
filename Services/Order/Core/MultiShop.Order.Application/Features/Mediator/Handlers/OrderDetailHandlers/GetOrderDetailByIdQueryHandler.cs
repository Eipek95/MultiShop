using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetOrderDetailByIdQueryResult>(values);
            //return new GetOrderDetailByIdQueryResult
            //{
            //    OrderDetailId = values.OrderDetailId,
            //    OrderingId = values.OrderingId,
            //    ProductAmount = values.ProductAmount,
            //    ProductId = values.ProductId,
            //    ProductName = values.ProductName,
            //    ProductPrice = values.ProductPrice,
            //    ProductTotalPrice = values.ProductTotalPrice,
            //};
        }
    }
}
