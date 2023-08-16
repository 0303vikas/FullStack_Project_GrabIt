using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class CategoryReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
    }

    public class CategoryUpdateDto
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }

    }
}