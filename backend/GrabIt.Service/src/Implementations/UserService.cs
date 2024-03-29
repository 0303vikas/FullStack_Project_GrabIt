using AutoMapper;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Service.src.Implementations;

namespace GrabIt.Service.Implementations
{
    public class UserService : BaseService<User, UserReadDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async Task<UserReadDto> CreateAdmin(UserCreateDto user)
        {
            // check user
            if (user == null) throw ErrorHandlerService.ExceptionNotFound("User not found.");
            var userEntity = _mapper.Map<User>(user);
            // update user role
            HashingService.HashPassword(userEntity.Password, out var salt, out var hashPassword);
            userEntity.Password = hashPassword;
            userEntity.Salt = salt;

            var createdUser = await _userRepo.CreateAdmin(userEntity) ?? throw ErrorHandlerService.ExceptionInternalServerError("User not created.");

            return _mapper.Map<UserReadDto>(createdUser);
        }

        public override async Task<UserReadDto> CreateOne(UserCreateDto createData)
        {
            // Check Empty
            if (
                createData.Email == "" ||
                createData.FirstName == "" ||
                createData.LastName == ""
                ) throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be empty.");
            // Check null Data 
            if (
                createData.Email == null ||
                createData.FirstName == null ||
                createData.LastName == null
                ) throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be null.");
            // Check Email Duplicate            
            if (!await _userRepo.CheckEmailAvailability(createData.Email)) throw ErrorHandlerService.ExceptionDuplicateData("Email already exists.");

            //Password Hashing
            var userEntity = _mapper.Map<User>(createData);
            HashingService.HashPassword(userEntity.Password, out var salt, out var hashPassword);
            userEntity.Password = hashPassword;
            userEntity.Salt = salt;

            var createdUser = await _userRepo.CreateOne(userEntity) ?? throw ErrorHandlerService.ExceptionInternalServerError("User not created.");
            //Error Handling
            return _mapper.Map<UserReadDto>(createdUser);
        }

        public override async Task<UserReadDto> UpdateOneById(Guid id, UserUpdateDto updateData)
        {
            // Check Empty
            if (
                updateData.Email == "" ||
                updateData.FirstName == "" ||
                updateData.LastName == ""
                ) throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be empty.");
            // Check null Data 
            if (
                updateData.Email == null ||
                updateData.FirstName == null ||
                updateData.LastName == null
                ) throw ErrorHandlerService.ExceptionNotFound("Email, FirstName, LastName cannot be null.");
            // Check Email Duplicate
            if (!await _userRepo.CheckEmailAvailability(updateData.Email, id)) throw ErrorHandlerService.ExceptionDuplicateData("Email already exists.");

            var updatedUser = await base.UpdateOneById(id, updateData) ?? throw ErrorHandlerService.ExceptionInternalServerError("User not updated.");
            //Error Handling
            return updatedUser;
        }

        public async Task<UserReadDto> UpdatePassword(Guid userId, string password)
        {
            var userEntity = await _userRepo.GetOneById(userId) ?? throw ErrorHandlerService.ExceptionNotFound("User not found.");

            HashingService.HashPassword(password, out var salt, out var hashPassword);
            userEntity.Password = hashPassword;
            userEntity.Salt = salt;
            var updatedUser = await _userRepo.UpdatePassword(userEntity) ?? throw ErrorHandlerService.ExceptionInternalServerError("User not updated.");
            return _mapper.Map<UserReadDto>(updatedUser);
        }

        public async Task<bool> CheckEmailAvailability(Guid id, string email)
        {
            return await _userRepo.CheckEmailAvailability(email, id);
        }
    }
}