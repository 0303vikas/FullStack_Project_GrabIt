using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class GenericBaseControllerWithoutGetMethods<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        private readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _baseService;

        public GenericBaseControllerWithoutGetMethods(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult> DeleteOneById([FromRoute] Guid id)
        {
            var delResult = await _baseService.DeleteOneById(id);
            if (!delResult) return NotFound();
            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        public virtual async Task<ActionResult<TReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] TUpdateDto updateData)
        {
            var updateResult = await _baseService.UpdateOneById(id, updateData);
            if (updateResult == null) return NotFound();
            return Ok(updateResult);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TReadDto>> CreateOne([FromBody] TCreateDto createData)
        {
            return Created(nameof(CreateOne), await _baseService.CreateOne(createData));
        }
    }
}