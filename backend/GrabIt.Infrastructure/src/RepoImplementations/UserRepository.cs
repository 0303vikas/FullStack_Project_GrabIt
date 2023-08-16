using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
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
            if (await _users.FirstOrDefaultAsync(u => u.Email == email && u.Id != userId) == null) return false;
            else return true;
        }

        public async Task<User> CreateAdmin(User user)
        {
            user.Role = UserRole.Admin;
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<User?> FindOneByEmail(string email)
        {
            return _users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public override Task<User> CreateOne(User createData)
        {
            createData.Role = UserRole.Customer;
            return base.CreateOne(createData);
        }

        public Task<User> UpdatePassword(User user)
        {
            _users.Update(user);
            _context.SaveChanges();
            return Task.FromResult(user);
        }
    }


}