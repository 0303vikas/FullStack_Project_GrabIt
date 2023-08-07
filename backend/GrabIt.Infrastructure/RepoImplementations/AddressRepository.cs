using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class AddressRepository : IAddressRepo
    {
        public bool DeleteOneById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAllUserAddressById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Address GetOneById(string id)
        {
            throw new NotImplementedException();
        }
    }
}