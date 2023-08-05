

using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class BaseServiceWithoutDto<T> : IBaseServiceWithoutDto<T>
    {
        private readonly IBaseRepo<T> _baseRepo;

        public BaseServiceWithoutDto(IBaseRepo<T> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public bool DeleteOneById(string id)
        {
            GetOneById(id);
            _baseRepo.DeleteOneById(id);
            return true;
        }

        public IEnumerable<T> GetAll(QueryOptions queryType)
        {
            return _baseRepo.GetAll(queryType);
        }

        public T GetOneById(string id)
        {
            var foundItem = _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            return foundItem;
        }

        public T UpdateOneById(string id, T updateData)
        {
            var foundEntity = GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            return _baseRepo.UpdateOne(foundEntity, foundEntity);
        }
    }
}