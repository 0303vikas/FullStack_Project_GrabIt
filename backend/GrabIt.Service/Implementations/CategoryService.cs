using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class CategoryService : BaseServiceWithoutDto<Category>
    {
        public CategoryService(ICategoryRepo categoryRepo) : base(categoryRepo)
        {
        }
    }
}