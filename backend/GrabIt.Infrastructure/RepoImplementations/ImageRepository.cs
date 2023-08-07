using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class ImageRepository : IImageRepo
    {
        public bool DeleteOneById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetAll(QueryOptions queryType)
        {
            throw new NotImplementedException();
        }

        public Image GetOneById(string id)
        {
            throw new NotImplementedException();
        }

        public Image UpdateOne(Image originalData, Image updateData)
        {
            throw new NotImplementedException();
        }
    }
}