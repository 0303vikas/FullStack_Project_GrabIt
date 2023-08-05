using GrabIt.Core.src.Entities;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAllUserAddressById(IEnumerable<string> ids);
        bool DeleteOneById(string id);
    }
}