using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepo
    {
        public AddressRepository(DatabaseContext context) : base(context) { }
    }
}