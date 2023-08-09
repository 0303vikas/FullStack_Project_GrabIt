using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IOrderRepo : IBaseWithCreateMethod<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserId(string id);
        Task<Order> UpdateOrderStatus(string id, OrderStatusType orderStatus);
        Task<bool> CancelOrder(string id);
    }
}