using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/Addresses")]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService baseRepo)
        {
            _addressService = baseRepo;
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult> DeleteOneById([FromRoute] Guid id)
        {
            var delResult = await _addressService.DeleteOneById(id);
            if (!delResult) return NotFound();
            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        public virtual async Task<ActionResult<AddressReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] AddressUpdateDto updateData)
        {
            var updateResult = await _addressService.UpdateOneById(id, updateData);
            if (updateResult == null) return NotFound();
            return Ok(updateResult);
        }

        [HttpPost]
        public virtual async Task<ActionResult<AddressReadDto>> CreateOne([FromBody] AddressCreateDto createData)
        {
            return Created(nameof(CreateOne), await _addressService.CreateOne(createData));
        }



    }
}