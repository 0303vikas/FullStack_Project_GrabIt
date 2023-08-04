
using GrabIt.Core.src.Shared;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IBaseService<T, TDto>
    {
        IEnumerable<TDto> GetAll(QueryOptions queryType);
        TDto GetOneById(string id);
        bool DeleteOneById(string id);
        TDto UpdateOneById(string id, TDto updateData);
    }
}