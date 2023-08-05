

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

        public IEnumerable<ProductDto> GetAllByCategoryId(string categoryId)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(_productRepo.GetAllByCategoryId(categoryId));
        }
    }
}