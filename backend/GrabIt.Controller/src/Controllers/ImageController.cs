using GrabIt.Core.src.Entities;
using GrabIt.Service.src.Dtos;
using GrabIt.Service.src.ServiceInterfaces;

namespace GrabIt.Controller.src.Controllers
{
    public class ImageController : GenericBaseController<Image, ImageReadDto, ImageCreateDto, ImageUpdateDto>
    {
        public ImageController(IImageService baseRepo) : base(baseRepo)
        {
        }
    }
}