using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class CartService : BaseService<Cart, CartReadDto, CartCreateDto, CartUpdateDto>, ICartService
    {
        public CartService(ICartRepo cartRepo, IMapper mapper) : base(cartRepo, mapper)
        {
        }
    }
}