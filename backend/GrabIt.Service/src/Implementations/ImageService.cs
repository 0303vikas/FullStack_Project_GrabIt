using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.src.Dtos;
using GrabIt.Service.src.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class ImageService : BaseService<Image, ImageReadDto, ImageCreateDto, ImageUpdateDto>, IImageService
    {
        private IImageRepo _imageRepo;
        public ImageService(IImageRepo imageRepo, IMapper mapper) : base(imageRepo, mapper)
        {
            _imageRepo = imageRepo;
        }

        public override async Task<ImageReadDto> CreateOne(ImageCreateDto createData)
        {
            if (createData.URL == null || createData.URL == "") throw ErrorHandlerService.ExceptionArgumentNull("ImageUrl can't be null or empty.");
            var createdEntity = await base.CreateOne(createData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error creating Image.");
            return createdEntity;
        }

        public override async Task<ImageReadDto> UpdateOneById(Guid id, ImageUpdateDto updateData)
        {
            if (updateData.URL == null || updateData.URL == "") throw ErrorHandlerService.ExceptionArgumentNull("ImageUrl can't be null or empty.");
            var createdEntity = await base.UpdateOneById(id, updateData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error creating Image.");
            return createdEntity;
        }
    }
}