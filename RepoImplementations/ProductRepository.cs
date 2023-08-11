using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class ProductRepository : IProductRepo
    {
        // public Product CreateOne(Product createData)
        // {
        //     throw new NotImplementedException();
        // }

        // public bool DeleteOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public IEnumerable<Product> GetAll(QueryOptions queryType)
        // {
        //     throw new NotImplementedException();
        // }

        // public IEnumerable<Product> GetAllByCategoryId(string categoryId)
        // {
        //     throw new NotImplementedException();
        // }

        // public Product GetOneById(string id)
        // {
        //     throw new NotImplementedException();
        // }

        // public Product UpdateOne(Product originalData, Product updateData)
        // {
        //     throw new NotImplementedException();
        // }
        public Task<Product> CreateOne(Product createData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllByCategoryId(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateOne(Product originalData, Product updateData)
        {
            throw new NotImplementedException();
        }
    }
}