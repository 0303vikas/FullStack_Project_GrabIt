namespace GrabIt.Service.Dtos
{
    public class ImageReadDto
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
    }

    public class ImageCreateDto
    {
        public string URL { get; set; }
    }

    public class ImageUpdateDto
    {
        public string URL { get; set; }
    }

}