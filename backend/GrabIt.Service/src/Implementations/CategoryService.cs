using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class CategoryService : BaseService<Category, CategoryReadDto, CategoryCreateDto, CategoryUpdateDto>, ICategoryService
    {
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper) : base(categoryRepo, mapper)
        {
        }

        public override async Task<CategoryReadDto> CreateOne(CategoryCreateDto createData)
        {
            if (createData.Name == null || createData.Name == "") throw ErrorHandlerService.ExceptionArgumentNull("Category Name can't be null or empty.");
            var createdEntity = await base.CreateOne(createData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error creating Category.");
            return createdEntity;
        }

        public override async Task<CategoryReadDto> UpdateOneById(Guid id, CategoryUpdateDto updateData)
        {
            if (updateData.Name == null || updateData.Name == "") throw ErrorHandlerService.ExceptionArgumentNull("Category Name can't be null or empty.");
            _ = await GetOneById(id) ?? throw ErrorHandlerService.ExceptionNotFound($"No Category with id: {id} was found.");

            var createdEntity = await base.UpdateOneById(id, updateData) ?? throw ErrorHandlerService.ExceptionInternalServerError($"Error Updating Category.");
            return createdEntity;
        }
    }
}