
using GrabIt.Core.src.Shared;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IBaseServiceWithoutDto<T>
    {
        IEnumerable<T> GetAll(QueryOptions queryType);
        T GetOneById(string id);
        bool DeleteOneById(string id);
        T UpdateOneById(string id, T updateData);

    }
}