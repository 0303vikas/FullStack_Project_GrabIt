using GrabIt.Core.src.Shared;
using GrabIt.Service.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrabIt.Controller.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class GenericBaseController<T, TDto> : ControllerBase
    {
        private readonly IBaseService<T, TDto> _baseRepo;

        public GenericBaseController(IBaseService<T, TDto> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetAll([FromQuery] QueryOptions options)
        {
            var result = await _baseRepo.GetAll(options);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetOneById(Guid id)
        {
            var result = await _baseRepo.GetOneById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOneById(Guid id)
        {
            var result = await _baseRepo.DeleteOneById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDto>> UpdateOneById(Guid id, TDto updateData)
        {
            var result = await _baseRepo.UpdateOneById(id, updateData);
            return Ok(result);
        }
    }
}