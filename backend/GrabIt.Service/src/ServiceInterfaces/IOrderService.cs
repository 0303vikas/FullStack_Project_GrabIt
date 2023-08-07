using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IOrderService : IBaseService<Order, OrderDto>
    {
        IEnumerable<OrderDto> GetOrdersByUserId(string id);
        OrderDto UpdateOrderStatus(string id, OrderStatusType orderStatus);
        bool CancelOrder(string id);
    }
}