
using GrabIt.Core.src.Shared;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IBaseRepo<T>
    {
        Task<IEnumerable<T>> GetAll(QueryOptions queryType);
        Task<T> GetOneById(string id);
        Task<bool> DeleteOneById(string id);
        Task<T> UpdateOne(T originalData, T updateData);
    }
}