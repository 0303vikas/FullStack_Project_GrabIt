using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IBaseWithCreateMethod<T> : IBaseRepo<T>
    {
        Task<T> CreateOne(T createData);

    }
}