using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    public class OrderProductController : GenericBaseController<OrderProduct, OrderProductReadDto, OrderProductCreateDto, OrderProductUpdateDto>
    {
        public OrderProductController(IOrderProductService baseRepo) : base(baseRepo)
        {
        }
    }
}