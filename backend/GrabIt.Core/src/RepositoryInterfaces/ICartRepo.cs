using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface ICartRepo
    {
        Cart GetOneByUserId(string userId);
        bool DeleteOneByUserId(string userId);

    }
}