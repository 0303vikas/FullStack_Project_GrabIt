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

        public Task<bool> CheckEmailDuplicate(string email, Guid? userId = null)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindOneByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }
    }


}