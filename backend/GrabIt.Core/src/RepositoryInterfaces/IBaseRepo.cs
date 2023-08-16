using GrabIt.Core.src.Shared;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IBaseRepo<T>
    {
        Task<IEnumerable<T>> GetAll(QueryOptions queryType);
        Task<T?> GetOneById(Guid id);
        Task<bool> DeleteOneById(Guid id);
        Task<T> UpdateOne(T updateData);
        Task<T> CreateOne(T createData);
    }
}