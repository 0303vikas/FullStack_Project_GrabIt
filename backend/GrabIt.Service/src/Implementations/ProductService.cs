using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo, IMapper mapper) : base(productRepo, mapper)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllByCategoryId(Guid categoryId)
        {
            if (categoryId == Guid.Empty) throw ErrorHandlerService.ExceptionArgumentNull($"{nameof(categoryId)} can't be empty or null.");
            return _mapper.Map<IEnumerable<ProductReadDto>>(await _productRepo.GetAllByCategoryId(categoryId));
        }

        public override async Task<ProductReadDto> CreateOne(ProductCreateDto createData)
        {
            if (createData.Title == null || createData.Description == null || createData.Price <= 0 || createData.Stock <= 0) throw ErrorHandlerService.ExceptionArgumentNull($"While Creating new Product title, discription, price, stock can't be null.");
            var createdEntity = await base.CreateOne(createData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error occured while creating new Product.");
            return createdEntity;
        }
    }
}