using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class ImageRepository : BaseRepository<Image>, IImageRepo
    {
        public ImageRepository(DatabaseContext context) : base(context) { }

    }
}