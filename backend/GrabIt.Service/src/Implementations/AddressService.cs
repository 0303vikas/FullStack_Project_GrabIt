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

        public async Task<bool> DeleteOneById(Guid id)
        {
            _ = await _addressRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            await _addressRepo.DeleteOneById(id);
            return true;
        }

        public async Task<IEnumerable<Address>> GetAllUserAddressById(IEnumerable<Guid> ids)
        {
            if (ids.Count() <= 0)
            {
                return new List<Address>();
            }
            return await _addressRepo.GetAllByUserId(ids);
        }


    }
}