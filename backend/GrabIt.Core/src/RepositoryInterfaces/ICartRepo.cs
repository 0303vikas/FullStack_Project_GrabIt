using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface ICartRepo
    {
        Task<Cart> GetOneByUserId(Guid userId);
        Task<bool> DeleteOneByUserId(Guid userId);
        Task<Cart> CreateOneWithUserId(Guid id, Cart cart);
        Task<Cart> UpdateOneByUserId(Guid id, Cart cart);

    }
}