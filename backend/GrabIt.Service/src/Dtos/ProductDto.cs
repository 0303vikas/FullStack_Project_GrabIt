using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class ProductReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public List<string> ImageURLList { get; set; }


        public CategoryReadDto Category { get; set; }
    }

    public class ProductCreateDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
        public List<string> ImageURLList { get; set; }
    }

    public class ProductUpdateDto
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
        public List<string> ImageURLList { get; set; }
    }

    public class ProuctReadWithoutNavigationalPropertiesDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public List<string> ImageURLList { get; set; }
    }
}