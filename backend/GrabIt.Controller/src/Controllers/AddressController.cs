using GrabIt.Core.src.Entities;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Service.src.Dtos;

namespace GrabIt.Controller.src.Controllers
{
    public class AddressController : GenericBaseController<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>
    {
        public AddressController(IAddressService baseRepo) : base(baseRepo)
        {
        }


    }
}