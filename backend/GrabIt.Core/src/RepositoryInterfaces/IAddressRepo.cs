using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IAddressRepo
    {
        IEnumerable<Address> GetAllUserAddressById(IEnumerable<string> ids);
        bool DeleteOneById(string id);
        Address GetOneById(string id);
    }
}