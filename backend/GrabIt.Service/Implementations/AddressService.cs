using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepo _addressRepo;

        public AddressService(IAddressRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }

        public bool DeleteOneById(string id)
        {
            _ = _addressRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            _addressRepo.DeleteOneById(id);
            return true;
        }

        public IEnumerable<Address> GetAllUserAddressById(IEnumerable<string> ids)
        {
            if (ids.Count() <= 0)
            {
                return new List<Address>();
            }
            return _addressRepo.GetAllUserAddressById(ids);
        }
    }
}