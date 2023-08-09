using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IOrderService : IBaseService<Order, OrderDto>
    {
        Task<IEnumerable<OrderDto>> GetOrdersByUserId(string id);
        Task<OrderDto> UpdateOrderStatus(string id, OrderStatusType orderStatus);
        Task<bool> CancelOrder(string id);
    }
}