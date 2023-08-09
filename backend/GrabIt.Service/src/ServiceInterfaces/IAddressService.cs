using GrabIt.Core.src.Entities;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllUserAddressById(IEnumerable<string> ids);
        Task<bool> DeleteOneById(string id);
    }
}