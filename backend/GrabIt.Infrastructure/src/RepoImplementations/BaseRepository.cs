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

        public virtual async Task<T> CreateOne(T createData)
        {
            await _dbSet.AddAsync(createData);
            await _context.SaveChangesAsync();
            Console.WriteLine($"CreatedOne image hello: {createData}");
            return createData;
        }

        public async Task<bool> DeleteOneById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll(QueryOptions queryType)
        {
            return await _dbSet.ToArrayAsync();
        }

        public async Task<T?> GetOneById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> UpdateOne(T updateData)
        {
            _dbSet.Update(updateData);
            await _context.SaveChangesAsync();
            return updateData;

        }
    }
}