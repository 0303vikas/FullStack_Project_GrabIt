using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using GrabIt.Infrastructure.src.Shared;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class UserRepository : BaseRepository<User>, IUserRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<User> _users;
        public UserRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _users = _context.Users;
        }

        public async Task<bool> CheckEmailDuplicate(string email, Guid? userId = null)
        {
            if (await _users.FirstOrDefaultAsync(u => u.Email == email && u.Id != userId) == null) return true;
            else return false;
        }

        public async Task<User> CreateAdmin(User user)
        {
            user.Role = UserRole.Admin;
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> FindOneByEmail(string email)
        {
            return await _users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<User> CreateOne(User createData)
        {
            createData.Role = UserRole.Customer;
            return await base.CreateOne(createData);
        }

        public async Task<User> UpdatePassword(User user)
        {
            _users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public override async Task<IEnumerable<User>> GetAll(QueryOptions queryType)
        {
            IQueryable<User> queryBuilder = _users.Include(e => e.Addresses).Include(e => e.Orders);
            // check search string
            if (!string.IsNullOrEmpty(queryType.SearchString))
            {
                queryBuilder = queryBuilder.Where(e => e.FirstName.Contains(queryType.SearchString) || e.LastName.Contains(queryType.SearchString) || e.Email.Contains(queryType.SearchString));
            }

            //  sorting 
            switch (queryType.Sort)
            {
                case SortMethods.Asc:
                    queryBuilder = queryBuilder.OrderBy(e => e.FirstName);
                    break;
                case SortMethods.Desc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.FirstName);
                    break;
                case SortMethods.UpdatedAt:
                    queryBuilder = queryBuilder.OrderBy(e => e.UpdatedAt);
                    break;
                case SortMethods.CreatedAt:
                    queryBuilder = queryBuilder.OrderBy(e => e.CreatedAt);
                    break;
                case SortMethods.UpdatedAtDesc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.UpdatedAt);
                    break;
                case SortMethods.CreatedAtDesc:
                    queryBuilder = queryBuilder.OrderByDescending(e => e.CreatedAt);
                    break;
                default:
                    queryBuilder = queryBuilder.OrderBy(e => e.CreatedAt);
                    break;
            }

            return await Pagination<User>.CreateAsync(queryBuilder.AsNoTracking(), queryType.PageNumber, queryType.PerPage);
        }
    }
}