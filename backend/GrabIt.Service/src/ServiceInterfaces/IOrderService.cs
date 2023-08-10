using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IOrderService : IBaseService<Order, OrderDto>
    {
        Task<IEnumerable<OrderDto>> GetOrdersByUserId(Guid id);
        Task<OrderDto> UpdateOrderStatus(Guid id, OrderStatusType orderStatus);
        Task<OrderProductDto> CreateOne(OrderProductDto createData);
    }
}