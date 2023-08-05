

using GrabIt.Core.src.Entities;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAddUserAddressById(IEnumerable<string> ids);
        bool DeleteOneById(string id);
    }
}