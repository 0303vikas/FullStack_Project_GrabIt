using GrabIt.Core.src.Entities;
using GrabIt.Service.Dtos;

namespace GrabIt.Service.ServiceInterfaces
{
    public interface ICartService
    {
        CartDto GetOneByUserId(string userId);
        bool DeleteOneByUserId(string userId);
    }
}