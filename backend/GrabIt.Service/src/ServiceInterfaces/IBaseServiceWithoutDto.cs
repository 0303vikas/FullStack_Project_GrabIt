using GrabIt.Core.src.Shared;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IBaseServiceWithoutDto<T>
    {
        Task<IEnumerable<T>> GetAll(QueryOptions queryType);
        Task<T> GetOneById(Guid id);
        Task<bool> DeleteOneById(Guid id);
        Task<T> UpdateOneById(Guid id, T updateData);

    }
}