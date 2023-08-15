using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.src.RepoImplementations
{
    public class BaseRepository<T> : IBaseRepo<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DatabaseContext _context;

        public BaseRepository(DatabaseContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public Task<T> CreateOne(T createData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateOne(T originalData, T updateData)
        {
            throw new NotImplementedException();
        }
    }
}