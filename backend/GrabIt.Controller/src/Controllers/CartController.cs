using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    public class CartController : GenericBaseController<Cart, CartReadDto, CartCreateDto, CartUpdateDto>
    {
        public CartController(ICartService baseRepo) : base(baseRepo)
        {
        }
    }
}