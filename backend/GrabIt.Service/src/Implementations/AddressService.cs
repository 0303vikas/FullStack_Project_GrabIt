using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Service.src.Dtos;

namespace GrabIt.Service.Implementations
{
    public class AddressService : BaseService<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>, IAddressService
    {
        private readonly IAddressRepo _addressRepo;

        public AddressService(IAddressRepo addressRepo, IMapper mapper) : base(addressRepo, mapper)
        {
            _addressRepo = addressRepo;
        }

        public Task<AddressReadDto> CreateOne(AddressReadDto createData)
        {
            throw new NotImplementedException();
        }

        // public override async Task<AddressReadDto> CreateOne(AddressCreateDto createData)
        // {
        //     //Error handling
        //     if(createData.Street == null || createData.City == null || createData.State == null || createData.Country == null || createData.PostalCode == null) throw ErrorHandlerService.ExceptionArgumentNull("Street, City, State, Country, PostalCode can't be null.");
        //     if(createData.Street == "" || createData.City == "" || createData.State == "" || createData.Country == "" || createData.PostalCode == "") throw ErrorHandlerService.ExceptionArgumentNull("Street, City, State, Country, PostalCode can't be empty.");

        //     var createdEntity = await base.CreateOne(createData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error creating Address.");

        //     return await base.CreateOne(createData);
        // }


        // public async Task<IEnumerable<Address>> GetAllUserAddressByAddressId(IEnumerable<Guid> ids)
        // {
        //     if (ids.Count() <= 0)
        //     {
        //         return new List<Address>();
        //     }
        //     return await _addressRepo.GetAllByUserId(ids);
        // }
    }
}