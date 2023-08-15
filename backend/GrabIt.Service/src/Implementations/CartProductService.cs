using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.src.Dtos;

namespace GrabIt.Service.Implementations
{
    public class CartProductService : BaseService<CartProduct, CartProductReadDto, CartProductCreateDto, CartProductUpdateDto>
    {
        public CartProductService(ICartProductRepo baseRepo, IMapper mapper) : base(baseRepo, mapper)
        {
        }
    }
}