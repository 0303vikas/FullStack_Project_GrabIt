using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class OrderService : BaseService<Order, OrderDto>, IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo, IMapper mapper) : base(orderRepo, mapper)
        {
            _orderRepo = orderRepo;
        }

        public Task<OrderProductDto> CreateOne(OrderProductDto createData)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserId(Guid id)
        {
            _ = await _orderRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Order with id: {id} was found.");
            var foundOrders = await _orderRepo.GetOrdersByUserId(id);
            return _mapper.Map<IEnumerable<OrderDto>>(foundOrders);
        }

        public async Task<OrderDto> UpdateOrderStatus(Guid id, OrderStatusType orderStatus)
        {
            _ = await _orderRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Order with id: {id} was found.");
            var updatedOrder = await _orderRepo.UpdateOrderStatus(id, orderStatus);
            return _mapper.Map<OrderDto>(updatedOrder);
        }
    }

}