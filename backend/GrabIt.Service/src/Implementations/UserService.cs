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
            await GetOneById(user.Id);
            // check user role
            if (user.Role != UserRole.Customer) throw ErrorHandlerService.ExceptionBadRequest("User is already admin.");
            // update user role

            return _mapper.Map<UserReadDto>(await _userRepo.CreateAdmin(user));
        }

        public async Task<UserReadDto> GetProfile(Guid id)
        {
            // check if user exists
            await GetOneById(id);
            return _mapper.Map<UserReadDto>(await _userRepo.GetProfile(id));
        }

        public override async Task<UserReadDto> CreateOne(UserCreateDto createData)
        {
            // Check Empty
            if (createData.Email == "" || createData.FirstName == "" || createData.LastName == "") throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be empty.");
            // Check null Data 
            if (createData.Email == null || createData.FirstName == null || createData.LastName == null) throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be null.");
            // Check Email Duplicate
            if (await _userRepo.CheckEmailDuplicate(createData.Email)) throw ErrorHandlerService.ExceptionDuplicateData("Email already exists.");

            var createdUser = await base.CreateOne(createData) ?? throw ErrorHandlerService.ExceptionInternalServerError("User not created.");
            //Error Handling
            return createdUser;
        }

        public override async Task<UserReadDto> UpdateOneById(Guid id, UserUpdateDto updateData)
        {
            // Check Empty
            if (updateData.Email == "" || updateData.FirstName == "" || updateData.LastName == "") throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be empty.");
            // Check null Data 
            if (updateData.Email == null || updateData.FirstName == null || updateData.LastName == null) throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be null.");

            var updatedUser = await base.UpdateOneById(id, updateData) ?? throw ErrorHandlerService.ExceptionInternalServerError("User not updated.");
            //Error Handling
            return updatedUser;
        }
    }
}