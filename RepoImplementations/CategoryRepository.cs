using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class CategoryRepository : ICategoryRepo
    {
        // public Category CreateOne(Category createData)
        // {
        //     throw new NotImplementedException();
        // }

        // public bool DeleteOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public IEnumerable<Category> GetAll(QueryOptions queryType)
        // {
        //     throw new NotImplementedException();
        // }

        // public Category GetOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public Category UpdateOne(Category originalData, Category updateData)
        // {
        //     throw new NotImplementedException();
        // }
        public Task<Category> CreateOne(Category createData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateOne(Category originalData, Category updateData)
        {
            throw new NotImplementedException();
        }
    }
}