using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
namespace GrabIt.Controller.src.Controllers
{
    public class AddressController : GenericBaseController<Address, AddressReadDto, AddressCreateDto, AddressUpdateDto>
    {
        public AddressController(IAddressService baseRepo) : base(baseRepo)
        {
        }


    }
}