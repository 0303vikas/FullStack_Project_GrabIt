using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IAddressRepo : IBaseRepo<Address>
    {
        Task<bool> UpdateUserAddress(Guid addressId);
    }
}