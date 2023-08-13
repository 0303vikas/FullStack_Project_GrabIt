using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserId(Guid userId);
        Task<Order> UpdateOrderStatus(Guid orderId, OrderStatusType orderStatus);
    }
}