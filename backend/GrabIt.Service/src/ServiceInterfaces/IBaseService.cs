
using GrabIt.Core.src.Shared;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IBaseService<T, TDto>
    {
        Task<IEnumerable<TDto>> GetAll(QueryOptions queryType);
        Task<TDto> GetOneById(string id);
        Task<bool> DeleteOneById(string id);
        Task<TDto> UpdateOneById(string id, TDto updateData);
    }
}