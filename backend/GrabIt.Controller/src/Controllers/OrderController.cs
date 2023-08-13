using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    public class OrderController : GenericBaseController<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        public OrderController(IOrderService baseRepo) : base(baseRepo)
        {
        }
    }
}