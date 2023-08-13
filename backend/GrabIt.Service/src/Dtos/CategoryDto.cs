using GrabIt.Core.src.Entities;

namespace GrabIt.Service.src.Dtos
{
    public class CategoryReadDto
    {
        public string Name { get; set; }
        public Image ImageUrl { get; set; }

    }

    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public Image ImageUrl { get; set; }
    }

    public class CategoryUpdateDto
    {
        public string Name { get; set; }
        public Image ImageUrl { get; set; }

    }
}