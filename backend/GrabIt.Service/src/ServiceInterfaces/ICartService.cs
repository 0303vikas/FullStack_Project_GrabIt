using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface ICartService : IBaseService<Cart, CartDto>
    {
        Task<CartDto> CreateOne(CartDto createData);

    }
}