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
        private readonly ICartRepo _cartRepo;
        public CartService(ICartRepo cartRepo, IMapper mapper) : base(cartRepo, mapper)
        {
            _cartRepo = cartRepo;
        }

        public override async Task<CartReadDto> GetOneById(Guid userId)
        {
            var foundItem = await _cartRepo.GetOneById(userId) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {userId} was found.");
            return _mapper.Map<CartReadDto>(foundItem);
        }
    }
}