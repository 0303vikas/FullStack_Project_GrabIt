using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;

namespace GrabIt.Service.Implementations
{
    public class CartProductService : BaseServiceWithoutDto<CartProduct>
    {
        public CartProductService(IBaseRepo<CartProduct> baseRepo) : base(baseRepo)
        {
        }
    }
}