using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class CartProductService : BaseService<CartProduct, CartProductReadDto, CartProductCreateDto, CartProductUpdateDto>, ICartProductService
    {
        public CartProductService(ICartProductRepo baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}