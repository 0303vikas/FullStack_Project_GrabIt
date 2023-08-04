
using GrabIt.Core.src.Shared;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IBaseRepo<T>
    {
        IEnumerable<T> GetAll(QueryOptions queryType);
        T GetOneById(string id);
        bool DeleteOneById(string id);
        T UpdateOneById(T originalData, T updateData);
    }
}