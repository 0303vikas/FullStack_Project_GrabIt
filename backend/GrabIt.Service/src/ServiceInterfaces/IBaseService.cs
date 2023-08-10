using GrabIt.Core.src.Shared;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IBaseService<T, TDto>
    {
        Task<IEnumerable<TDto>> GetAll(QueryOptions queryType);
        Task<TDto> GetOneById(Guid id);
        Task<bool> DeleteOneById(Guid id);
        Task<TDto> UpdateOneById(Guid id, TDto updateData);
    }
}