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

        public async Task<bool> DeleteOneById(Guid id)
        {
            await GetOneById(id);
            await _baseRepo.DeleteOneById(id);
            return true;
        }

        public async Task<IEnumerable<T>> GetAll(QueryOptions queryType)
        {
            return await _baseRepo.GetAll(queryType);
        }

        public async Task<T> GetOneById(Guid id)
        {
            var foundItem = await _baseRepo.GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            return foundItem;
        }

        public async Task<T> UpdateOneById(Guid id, T updateData)
        {
            var foundEntity = await GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Item with id: {id} was found.");
            return await _baseRepo.UpdateOne(foundEntity, foundEntity);
        }
    }
}