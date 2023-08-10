using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class OrderProductService : BaseService<OrderProduct, OrderProductDto>, IOrderProductService
    {
        private readonly IOrderProductRepo _orderProductRepo;

        public OrderProductService(IOrderProductRepo orderProductRepo, IMapper mapper) : base(orderProductRepo, mapper)
        {
            _orderProductRepo = orderProductRepo;
        }

        public async Task<OrderProductDto> CreateOne(OrderProductDto createData)
        {
            throw new NotImplementedException();
        }
    }
}