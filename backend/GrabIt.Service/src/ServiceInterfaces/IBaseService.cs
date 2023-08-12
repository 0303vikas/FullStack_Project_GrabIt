using GrabIt.Core.src.Shared;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryType);
        Task<TReadDto> GetOneById(Guid id);
        Task<bool> DeleteOneById(Guid id);
        Task<TReadDto> UpdateOneById(Guid id, TUpdateDto updateData);
        Task<TReadDto> CreateOne(TCreateDto createData);
    }
}