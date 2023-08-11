using GrabIt.Core.src.Entities;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IAddressService : IBaseServiceWithoutDto<Address>
    {
        Task<IEnumerable<Address>> GetAllUserAddressByAddressId(IEnumerable<Guid> ids);
        Task<Address> CreateOne(Address createData);
    }
}