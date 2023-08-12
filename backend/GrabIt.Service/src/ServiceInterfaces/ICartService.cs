using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface ICartService : IBaseService<Cart, CartReadDto, CartCreateDto, CartUpdateDto>
    {

    }
}