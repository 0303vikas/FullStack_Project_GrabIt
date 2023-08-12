using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;

namespace GrabIt.Service.Implementations
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async Task<UserReadDto> CreateAdmin(User user)
        {
            // check user
            if (user == null) throw ErrorHandlerService.ExceptionNotFound("User not found.");
            // check if user exists
            if (await base.GetOneById(user.Id) == null) throw ErrorHandlerService.ExceptionNotFound("User not found.");
            // check user role
            if (user.Role != UserRole.Customer) throw ErrorHandlerService.ExceptionBadRequest("User is already admin.");
            return await base.UpdateOneById(user.Id, new UserUpdateDto { Role = UserRole.Admin });
        }

        public async Task<UserReadDto> GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<UserReadDto> CreateOne(UserCreateDto createData)
        {
            // Check Empty
            if (createData.Email == "" || createData.FirstName == "" || createData.LastName == "") throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be empty.");
            // Check null Data 
            if (createData.Email == null || createData.FirstName == null || createData.LastName == null) throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be null.");
            // Check Email Duplicate
            if (await _userRepo.CheckEmailDuplicate(createData.Email)) throw ErrorHandlerService.ExceptionDuplicateData("Email already exists.");
            var createdUser = await base.CreateOne(createData) ?? throw ErrorHandlerService.ExceptionBadRequest("User not created.");
            //Error Handling
            return createdUser;
        }

        // public async Task<UserDto> CreateAdmin(User user)
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<OrderProductDto> CreateOne(OrderProductDto createData)
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<UserDto> GetProfile(Guid id)
        // {
        //     throw new NotImplementedException();
        // }


    }
}