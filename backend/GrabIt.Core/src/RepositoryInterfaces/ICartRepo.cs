using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface ICartRepo
    {
        Task<Cart> GetOneByUserId(string userId);
        Task<bool> DeleteOneByUserId(string userId);

    }
}