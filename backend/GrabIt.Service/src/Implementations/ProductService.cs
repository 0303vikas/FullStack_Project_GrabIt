using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class ProductService : BaseService<Product, ProductDto>, IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo, IMapper mapper) : base(productRepo, mapper)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<ProductDto>> GetAllByCategoryId(Guid categoryId)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepo.GetAllByCategoryId(categoryId));
        }

    }
}