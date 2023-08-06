using AutoMapper;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly IMapper _mapper;
        public CartService(ICartRepo cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        public bool DeleteOneByUserId(string userId)
        {
            _ = _cartRepo.GetOneByUserId(userId) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {userId} was found.");
            _cartRepo.DeleteOneByUserId(userId);
            return true;
        }

        public CartDto GetOneByUserId(string userId)
        {
            var foundCart = _cartRepo.GetOneByUserId(userId) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {userId} was found.");
            return _mapper.Map<CartDto>(foundCart);
        }
    }
}