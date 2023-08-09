using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface ICartService
    {
        Task<CartDto> GetOneByUserId(string userId);
        Task<bool> DeleteOneByUserId(string userId);
    }
}