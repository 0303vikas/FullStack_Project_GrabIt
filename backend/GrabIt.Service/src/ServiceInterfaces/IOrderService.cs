using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IOrderService : IBaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        Task<IEnumerable<OrderReadDto>> GetOrdersByUserId(Guid userId);
        Task<OrderReadDto> UpdateOrderStatus(Guid orderId, OrderStatusType orderStatus);
    }
}