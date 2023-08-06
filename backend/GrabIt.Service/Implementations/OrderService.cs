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

        public bool CancelOrder(string id)
        {
            _ = _orderRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Order with id: {id} was found.");
            _orderRepo.CancelOrder(id);
            return true;
        }

        public IEnumerable<OrderDto> GetOrdersByUserId(string id)
        {
            _ = _orderRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Order with id: {id} was found.");
            var foundOrders = _orderRepo.GetOrdersByUserId(id);
            return _mapper.Map<IEnumerable<OrderDto>>(foundOrders);
        }

        public OrderDto UpdateOrderStatus(string id, OrderStatusType orderStatus)
        {
            _ = _orderRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Order with id: {id} was found.");
            var updatedOrder = _orderRepo.UpdateOrderStatus(id, orderStatus);
            return _mapper.Map<OrderDto>(updatedOrder);
        }
    }

}