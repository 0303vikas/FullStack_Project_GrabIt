using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace GrabIt.Controller.src.Controllers
{
    [Authorize]
    public class CartProductController : GenericBaseControllerWithoutGetMethods<CartProduct, CartProductReadDto, CartProductCreateDto, CartProductUpdateDto>
    {

        public CartProductController(ICartProductService baseRepo) : base(baseRepo)
        {
        }

    }
}