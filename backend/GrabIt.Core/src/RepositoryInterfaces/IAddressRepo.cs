using GrabIt.Core.src.Entities;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IAddressRepo
    {
        Task<IEnumerable<Address>> GetAllByUserId(IEnumerable<Guid> ids);
        Task<bool> DeleteOneById(Guid id);
        Task<Address> GetOneById(Guid id);
        Task<Address> CreateOne(Address address);
        Task<Address> UpdateOneById(Guid id, Address address);
    }
}