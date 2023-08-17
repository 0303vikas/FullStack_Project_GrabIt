using GrabIt.Core.src.Shared;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class GenericBaseController<T, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
    {
        private readonly IBaseService<T, TReadDto, TCreateDto, TUpdateDto> _baseService;

        public GenericBaseController(IBaseService<T, TReadDto, TCreateDto, TUpdateDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TReadDto>>> GetAll([FromQuery] QueryOptions options)
        {
            var result = await _baseService.GetAll(options);
            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public virtual async Task<ActionResult<TReadDto>> GetOneById([FromRoute] Guid id)
        {
            var result = await _baseService.GetOneById(id);
            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public virtual async Task<ActionResult<bool>> DeleteOneById([FromRoute] Guid id)
        {
            var result = await _baseService.DeleteOneById(id);
            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public virtual async Task<ActionResult<TReadDto>> UpdateOneById([FromRoute] Guid id, [FromBody] TUpdateDto updateData)
        {
            var result = await _baseService.UpdateOneById(id, updateData);
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TReadDto>> CreateOne([FromBody] TCreateDto createData)
        {
            var result = await _baseService.CreateOne(createData);
            return Ok(result);
        }
    }
}