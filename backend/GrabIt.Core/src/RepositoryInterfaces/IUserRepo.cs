using GrabIt.Core.src.Entities;

// GetOne, GetAll, UpdateOne, DeleteOne, CreateOne, CreateAdmin, GetProfile
namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User> CreateAdmin(User user);
        Task<User> GetProfile(Guid id);
        Task<bool> CheckEmailDuplicate(string email, Guid? userId = null);
        Task<User?> FindOneByEmail(string email);
    }
}