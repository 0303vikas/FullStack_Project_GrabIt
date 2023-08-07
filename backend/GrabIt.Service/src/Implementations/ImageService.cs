
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;

namespace GrabIt.Service.Implementations
{
    public class ImageService : BaseServiceWithoutDto<Image>
    {
        public ImageService(IImageRepo imageRepo) : base(imageRepo)
        {
        }
    }
}