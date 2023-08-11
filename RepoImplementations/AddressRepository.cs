using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class AddressRepository : IAddressRepo
    {
        // public bool DeleteOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public IEnumerable<Address> GetAllUserAddressById(IEnumerable<string> ids)
        // {
        //     throw new NotImplementedException();
        // }

        // public Address GetOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }
        public Task<Address> CreateOne(Address createData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAllByUserId(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> UpdateOne(Address originalData, Address updateData)
        {
            throw new NotImplementedException();
        }
    }
}