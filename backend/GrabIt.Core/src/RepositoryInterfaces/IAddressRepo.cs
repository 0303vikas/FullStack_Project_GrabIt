using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IAddressRepo
    {
        Task<IEnumerable<Address>> GetAllUserAddressById(IEnumerable<string> ids);
        Task<bool> DeleteOneById(string id);
        Task<Address> GetOneById(string id);
    }
}