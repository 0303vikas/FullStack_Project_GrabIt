using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IOrderRepo : IBaseRepo<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserId(Guid id);
        Task<Order> UpdateOrderStatus(Guid id, OrderStatusType orderStatus);
    }
}