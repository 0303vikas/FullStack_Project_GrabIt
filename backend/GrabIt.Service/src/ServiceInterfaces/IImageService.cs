using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IImageService : IBaseService<Image, ImageReadDto, ImageCreateDto, ImageUpdateDto>
    {
    }
}