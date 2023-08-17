using AutoMapper;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        private readonly IBaseRepo<T> _baseRepo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> baseRepo, IMapper mapper)
        {
            _baseRepo = baseRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryType)
        {

            return _mapper.Map<IEnumerable<TReadDto>>(await _baseRepo.GetAll(queryType));
        }

        public virtual async Task<TReadDto> GetOneById(Guid id)
        {
            var foundItem = await _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            return _mapper.Map<TReadDto>(foundItem);
        }

        public async Task<bool> DeleteOneById(Guid id)
        {
            _ = await _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            await _baseRepo.DeleteOneById(id);
            return true;
        }

        public virtual async Task<TReadDto> UpdateOneById(Guid id, TUpdateDto updateData)
        {
            var foundEntity = await _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            _mapper.Map(updateData, foundEntity);
            var updatedEntity = await _baseRepo.UpdateOne(foundEntity) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error updating item with id: {id}");
            return _mapper.Map<TReadDto>(updatedEntity);
        }

        public virtual async Task<TReadDto> CreateOne(TCreateDto createData)
        {
            var createdEntity = await _baseRepo.CreateOne(_mapper.Map<T>(createData)) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error creating item.");
            return _mapper.Map<TReadDto>(createdEntity);
        }
    }
}