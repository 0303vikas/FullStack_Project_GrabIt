using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class UserRepository : IUserRepo
    {
        // public User CreateAdmin(User user)
        // {
        //     throw new NotImplementedException();
        // }

        // public User CreateOne(User createData)
        // {
        //     throw new NotImplementedException();
        // }

        // public bool DeleteOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public IEnumerable<User> GetAll(QueryOptions queryType)
        // {
        //     throw new NotImplementedException();
        // }

        // public User GetOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public User UpdateOne(User originalData, User updateData)
        // {
        //     throw new NotImplementedException();
        // }
        public Task<User> CreateAdmin(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateOne(User createData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateOne(User originalData, User updateData)
        {
            throw new NotImplementedException();
        }
    }
}