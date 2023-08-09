namespace GrabIt.Core.src.RepositoryInterfaces
{
    public interface IBaseWithCreateMethod<T> : IBaseRepo<T>
    {
        Task<T> CreateOne(T createData);
    }
}