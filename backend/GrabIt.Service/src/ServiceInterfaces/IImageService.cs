using GrabIt.Core.src.Entities;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Service.src.Dtos;

namespace GrabIt.Service.src.ServiceInterfaces
{
    public interface IImageService : IBaseService<Image, ImageReadDto, ImageCreateDto, ImageUpdateDto>
    {
    }
}