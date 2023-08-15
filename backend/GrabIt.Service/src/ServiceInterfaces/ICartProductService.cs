using GrabIt.Core.src.Entities;
using GrabIt.Service.src.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface ICartProductService : IBaseService<CartProduct, CartProductReadDto, CartProductCreateDto, CartProductUpdateDto>
    {

    }
}