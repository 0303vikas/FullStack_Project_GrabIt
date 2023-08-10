using AutoMapper;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class BaseService<T, TDto> : IBaseService<T, TDto>
    {
        private readonly IBaseRepo<T> _baseRepo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepo<T> baseRepo, IMapper mapper)
        {
            _baseRepo = baseRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAll(QueryOptions queryType)
        {
            return _mapper.Map<IEnumerable<TDto>>(await _baseRepo.GetAll(queryType));
        }

        public async Task<TDto> GetOneById(Guid id)
        {
            var foundItem = await _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            return _mapper.Map<TDto>(foundItem);
        }

        public async Task<bool> DeleteOneById(Guid id)
        {
            _ = await _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            await _baseRepo.DeleteOneById(id);
            return true;
        }

        public async Task<TDto> UpdateOneById(Guid id, TDto updateData)
        {
            var foundEntity = await _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            var updatedEntity = await _baseRepo.UpdateOne(foundEntity, _mapper.Map<T>(updateData));
            return _mapper.Map<TDto>(updatedEntity);
        }
    }
}