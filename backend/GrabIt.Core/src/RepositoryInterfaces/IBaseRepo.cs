using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IBaseRepo<T>
    {
        IEnumerable<T> GetAdd();
        T GetOneById(string id);
        bool DeleteOneById(string id);
        T UpdateOneById(T updateData);
    }
}