
namespace GrabIt.Core.src.Entities
{
    public class BaseEntityWithDate : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}