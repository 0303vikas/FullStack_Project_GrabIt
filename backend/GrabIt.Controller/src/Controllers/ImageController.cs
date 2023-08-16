using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    public class ImageController : GenericBaseController<Image, ImageReadDto, ImageCreateDto, ImageUpdateDto>
    {
        public ImageController(IImageService baseRepo) : base(baseRepo)
        {
        }
    }
}