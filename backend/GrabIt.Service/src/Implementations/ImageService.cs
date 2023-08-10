using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.src.Dtos;
using GrabIt.Service.src.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class ImageService : BaseService<Image, ImageDto>, IImageService
    {
        private IImageRepo _imageRepo;
        public ImageService(IImageRepo imageRepo, IMapper mapper) : base(imageRepo, mapper)
        {
            _imageRepo = imageRepo;
        }

        public Task<ImageDto> CreateOne(ImageDto createData)
        {
            throw new NotImplementedException();
        }
    }
}