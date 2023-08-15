using System.Threading.Tasks;
using GrabIt.Core.src.Entities;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Service.src.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrabIt.Controller.src.Controllers
{
    public class CartProductController : GenericBaseController<CartProduct, CartProductReadDto, CartProductCreateDto, CartProductUpdateDto>
    {

        public CartProductController(ICartProductService baseRepo) : base(baseRepo)
        {
        }

    }
}