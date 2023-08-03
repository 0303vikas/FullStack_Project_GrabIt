using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IUserRepo : IBaseWithCreateMethod<User>
    {
        User CreateAdmin(User user);


    }
}