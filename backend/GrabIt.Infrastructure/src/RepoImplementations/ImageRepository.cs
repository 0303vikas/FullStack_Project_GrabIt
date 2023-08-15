using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Infrastructure.Database;
using GrabIt.Infrastructure.src.RepoImplementations;
using Microsoft.EntityFrameworkCore;

namespace GrabIt.Infrastructure.RepoImplementations
{
    public class ImageRepository : BaseRepository<Image>, IImageRepo
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Image> _image;
        public ImageRepository(DatabaseContext context) : base(context)
        {
            _context = context;
            _image = _context.Images;
        }
    }
}