
using GrabIt.Core.src.Shared;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IBaseServiceWithoutDto<T>
    {
        Task<IEnumerable<T>> GetAll(QueryOptions queryType);
        Task<T> GetOneById(string id);
        Task<bool> DeleteOneById(string id);
        Task<T> UpdateOneById(string id, T updateData);

    }
}