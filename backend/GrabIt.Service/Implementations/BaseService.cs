using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Service.Dtos;
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
        public bool DeleteOneById(string id)
        {
            GetOneById(id);
            _baseRepo.DeleteOneById(id);
            return true;
        }

        public IEnumerable<TDto> GetAll(QueryOptions queryType)
        {
            return _mapper.Map<IEnumerable<TDto>>(_baseRepo.GetAll(queryType));
        }

        public TDto GetOneById(string id)
        {
            var foundItem = _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            return _mapper.Map<TDto>(foundItem);
        }

        public TDto UpdateOneById(string id, TDto updateData)
        {
            var foundEntity = _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            var updatedEntity = _baseRepo.UpdateOne(foundEntity, _mapper.Map<T>(updateData));
            return _mapper.Map<TDto>(updatedEntity);
        }
    }
}