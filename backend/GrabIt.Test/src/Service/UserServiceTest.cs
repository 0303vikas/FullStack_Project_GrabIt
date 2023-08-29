using System.Text;
using AutoMapper;
using Moq;

using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Core.src.Shared;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.Implementations;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Service.src.Implementations;

namespace GrabIt.Test.src.Service
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepo> _userRepoMock = new Mock<IUserRepo>();
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserReadDto>();
                cfg.CreateMap<UserCreateDto, User>();
                cfg.CreateMap<UserUpdateDto, User>();
                cfg.CreateMap<Task<UserReadDto>, User>();
            });
            var mapper = config.CreateMapper();
            _userService = new UserService(_userRepoMock.Object, mapper);
        }

        [Fact]
        public async Task CreateUser_ReturnUserReadVersion()
        {
            UserCreateDto userCreateDto = new UserCreateDto()
            {
                FirstName = "Michael",
                LastName = "Philips",
                Email = "michael@gmail.com",
                Password = "customer123",
                ImageURL = "https://image.com"
            };

            var testUser = new User()
            {
                FirstName = "Michael",
                LastName = "Philips",
                Email = "michael@gmail.com",
                Role = UserRole.Customer,
                Password = "customer123",
                ImageURL = "https://image.com",
            };

            _userRepoMock.Setup(repo => repo.CreateOne(It.IsAny<User>())).ReturnsAsync(testUser);
            _userRepoMock.Setup(repo => repo.CheckEmailDuplicate(userCreateDto.Email, Guid.NewGuid())).ReturnsAsync(false);


            var createdUser = await _userService.CreateOne(userCreateDto);

            _userRepoMock.Verify(repo => repo.CreateOne(It.IsAny<User>()), Times.Once);
            Assert.NotNull(createdUser);
            Assert.IsType<UserReadDto>(createdUser);
            Assert.Equal(testUser.FirstName, createdUser.FirstName);
            Assert.Equal(testUser.LastName, createdUser.LastName);
            Assert.Equal(testUser.Email, createdUser.Email);
            Assert.Equal(testUser.Role, createdUser.Role);
            Assert.Equal(testUser.ImageURL, createdUser.ImageURL);
        }

        [Fact]
        public async Task CreateAdmin_ReturnUserReadVersion()
        {
            UserCreateDto userCreateDto = new UserCreateDto()
            {
                FirstName = "Michael",
                LastName = "Philips",
                Email = "michael@gmail.com",
                Password = "customer123",
                ImageURL = "https://image.com"
            };

            var testUser = new User()
            {
                FirstName = "Michael",
                LastName = "Philips",
                Email = "michael@gmail.com",
                Role = UserRole.Admin,
                ImageURL = "https://image.com",
                Password = "customer123",

            };

            _userRepoMock.Setup(repo => repo.CreateAdmin(It.IsAny<User>())).ReturnsAsync(testUser);

            var createdUser = await _userService.CreateAdmin(userCreateDto);

            _userRepoMock.Verify(repo => repo.CreateAdmin(It.IsAny<User>()), Times.Once);
            Assert.NotNull(createdUser);
            Assert.IsType<UserReadDto>(createdUser);
            Assert.Equal(testUser.FirstName, createdUser.FirstName);
            Assert.Equal(testUser.LastName, createdUser.LastName);
            Assert.Equal(testUser.Email, createdUser.Email);
            Assert.Equal(testUser.Role, createdUser.Role);
            Assert.Equal(testUser.ImageURL, createdUser.ImageURL);
        }

        [Fact]
        public async Task UpdateUser_WithoutPasswordUpdate_ReturnUserReadVersion()
        {
            Guid userId = Guid.NewGuid();
            UserUpdateDto userUpdateDto = new UserUpdateDto()
            {
                FirstName = "MichaelUpdated",
                LastName = "PhilipsUpdated",
                Email = "michael@gmail.com",
                ImageURL = "https://image.com",
            };

            var testUser = new User()
            {
                FirstName = "Michael",
                LastName = "Philips",
                Email = "michael@gmail.com",
                Role = UserRole.Customer,
                ImageURL = "https://image.com",
                Password = "customer123",

            };

            var updateUser = new User()
            {
                FirstName = "MichaelUpdated",
                LastName = "PhilipsUpdated",
                Email = "michael@gmail.com",
                Role = UserRole.Customer,
                ImageURL = "https://image.com",
            };

            _userRepoMock.Setup(repo => repo.GetOneById(userId)).ReturnsAsync(testUser);
            _userRepoMock.Setup(repo => repo.CheckEmailDuplicate(userUpdateDto.Email, userId)).ReturnsAsync(false);
            _userRepoMock.Setup(repo => repo.UpdateOne(It.IsAny<User>())).ReturnsAsync(updateUser);

            var updatedUserResult = await _userService.UpdateOneById(userId, userUpdateDto);

            _userRepoMock.Verify(repo => repo.GetOneById(userId), Times.Once());
            _userRepoMock.Verify(
                repo => repo.UpdateOne(It.IsAny<User>()),
                Times.Once()
            );

            Assert.NotNull(updatedUserResult);
            Assert.IsType<UserReadDto>(updatedUserResult);
            Assert.Equal(userUpdateDto.FirstName, updatedUserResult.FirstName);
            Assert.Equal(userUpdateDto.LastName, updatedUserResult.LastName);
            Assert.Equal(userUpdateDto.Email, updatedUserResult.Email);
            Assert.Equal(updatedUserResult.Role, updatedUserResult.Role);
            Assert.Equal(userUpdateDto.ImageURL, updatedUserResult.ImageURL);
        }

        [Fact]
        public async Task UpdateUser_Throw_Error_if_FirstName_LastName_email_empty()
        {
            Guid userId = Guid.NewGuid();
            UserUpdateDto userUpdateDto = new UserUpdateDto()
            {
                FirstName = "",
                LastName = "",
                Email = "",
                ImageURL = "https://image.com",
            };

            await Assert.ThrowsAsync<ErrorHandlerService>(async () => await _userService.UpdateOneById(userId, userUpdateDto));

            _userRepoMock.Verify(repo => repo.GetOneById(userId), Times.Never());
            _userRepoMock.Verify(
                repo => repo.UpdateOne(It.IsAny<User>()),
                Times.Never()
            );
        }

        [Fact]
        public async Task UpdateUser_Throw_Error_if_Update_Email_is_Duplicate()
        {
            Guid userId = Guid.NewGuid();
            UserUpdateDto userUpdateDto = new UserUpdateDto()
            {
                FirstName = "Michael",
                LastName = "Kylian",
                Email = "BillGates@gmail.com",
                ImageURL = "https://image.com",
            };

            var testUser = new User()
            {
                FirstName = "Michael",
                LastName = "Philips",
                Email = "michael@gmail.com",
                Role = UserRole.Customer,
                ImageURL = "https://image.com",
                Password = "customer123",

            };

            _userRepoMock.Setup(repo => repo.CheckEmailDuplicate(userUpdateDto.Email, userId)).ReturnsAsync(true);

            await Assert.ThrowsAsync<ErrorHandlerService>(async () => await _userService.UpdateOneById(userId, userUpdateDto));

            _userRepoMock.Verify(repo => repo.GetOneById(userId), Times.Never());
            _userRepoMock.Verify(
                repo => repo.UpdateOne(It.IsAny<User>()),
                Times.Never()
            );
        }

        [Fact]
        public async Task UpdateUserPassword_WithUserId_ReturnUserReadVersion()
        {
            Guid userId = Guid.NewGuid();
            var user = new User()
            {
                Id = userId,
                FirstName = "MichaelUpdated",
                LastName = "PhilipsUpdated",
                Email = "michael@gmail.com",
                Role = UserRole.Customer,
                ImageURL = "https://image.com",
                Password = "customer123",
                Salt = Encoding.ASCII.GetBytes("salt")
            };

            var userWithUpdatedPassword = new User()
            {
                FirstName = "MichaelUpdated",
                LastName = "PhilipsUpdated",
                Email = "michael@gmail.com",
                Role = UserRole.Customer,
                ImageURL = "https://image.com",
                Password = "customer123",
                Salt = Encoding.ASCII.GetBytes("salt")
            };
            var newPassword = "updatecustomer123";
            HashingService.HashPassword(newPassword, out var salt, out var hashPassword);
            userWithUpdatedPassword.Password = hashPassword;
            userWithUpdatedPassword.Salt = salt;

            _userRepoMock.Setup(repo => repo.GetOneById(userId)).ReturnsAsync(user);
            _userRepoMock.Setup(repo => repo.UpdateOne(It.IsAny<User>())).ReturnsAsync(userWithUpdatedPassword);

            _userRepoMock.Setup(repo => repo.UpdatePassword(It.IsAny<User>())).ReturnsAsync(userWithUpdatedPassword);

            var updatedUserResult = await _userService.UpdatePassword(userId, newPassword);

            _userRepoMock.Verify(repo => repo.GetOneById(userId), Times.Once());

            _userRepoMock.Verify(
                repo => repo.UpdatePassword(It.IsAny<User>()),
                Times.Once()
            );

            Assert.NotNull(updatedUserResult);
            Assert.IsType<UserReadDto>(updatedUserResult);
            Assert.Equal(user.FirstName, updatedUserResult.FirstName);
        }

        [Fact]
        public async Task DelteOneBYId_Returns_True()
        {
            Guid userId = Guid.NewGuid();
            var user = new User()
            {
                Id = userId,
                FirstName = "MichaelUpdated",
                LastName = "PhilipsUpdated",
                Email = "michael@gmail.com",
                Role = UserRole.Customer,
                ImageURL = "https://image.com",
                Password = "customer123",
                Salt = Encoding.ASCII.GetBytes("salt")
            };

            _userRepoMock.Setup(repo => repo.GetOneById(userId)).ReturnsAsync(user);
            _userRepoMock.Setup(repo => repo.DeleteOneById(userId)).ReturnsAsync(true);

            var deletedUserResult = await _userService.DeleteOneById(userId);

            _userRepoMock.Verify(repo => repo.GetOneById(userId), Times.Once());
            _userRepoMock.Verify(repo => repo.DeleteOneById(userId), Times.Once());

            Assert.True(deletedUserResult);
        }

        [Fact]
        public async Task GetAll_Returns_ListOfUserReadDto()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "User1",
                    LastName = "lastName1",
                    Email = "user1@gmail.com",
                    Role = UserRole.Customer,
                    ImageURL = "https://image.com",
                    Password = "customer123",
                    Salt = Encoding.ASCII.GetBytes("salt")
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "User2",
                    LastName = "lastName2",
                    Email = "user2@gmail.com",
                    Role = UserRole.Customer,
                    ImageURL = "https://image.com",
                    Password = "customer123",
                    Salt = Encoding.ASCII.GetBytes("salt")
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "User3",
                    LastName = "lastName3",
                    Email = "user3@gmail.com",
                    Role = UserRole.Customer,
                    ImageURL = "https://image.com",
                    Password = "customer123",
                    Salt = Encoding.ASCII.GetBytes("salt")
                },
            };

            _userRepoMock.Setup(repo => repo.GetAll(It.IsAny<QueryOptions>())).ReturnsAsync(users);

            var usersResult = await _userService.GetAll(new QueryOptions());

            _userRepoMock.Verify(repo => repo.GetAll(It.IsAny<QueryOptions>()), Times.Once());

            Assert.NotNull(usersResult);
            Assert.IsType<List<UserReadDto>>(usersResult);
            Assert.Equal(users.Count, usersResult.Count());
        }

        [Fact]
        public async Task GetOneById_Returns_UserReadDto()
        {
            Guid user1Id = Guid.NewGuid();
            Guid user2Id = Guid.NewGuid();
            Guid user3Id = Guid.NewGuid();
            var users = new List<User>()
            {
                new User()
                {
                    Id = user1Id,
                    FirstName = "User1",
                    LastName = "lastName1",
                    Email = "user1@gmail.com",
                    Role = UserRole.Customer,
                    ImageURL = "https://image.com",
                    Password = "customer123",
                    Salt = Encoding.ASCII.GetBytes("salt")
                },
                new User()
                {
                    Id = user2Id,
                    FirstName = "User2",
                    LastName = "lastName2",
                    Email = "user2@gmail.com",
                    Role = UserRole.Customer,
                    ImageURL = "https://image.com",
                    Password = "customer123",
                    Salt = Encoding.ASCII.GetBytes("salt")
                },
                new User()
                {
                    Id = user3Id,
                    FirstName = "User3",
                    LastName = "lastName3",
                    Email = "user3@gmail.com",
                    Role = UserRole.Customer,
                    ImageURL = "https://image.com",
                    Password = "customer123",
                    Salt = Encoding.ASCII.GetBytes("salt")
                },
            };

            _userRepoMock.Setup(repo => repo.GetOneById(user1Id)).ReturnsAsync(users[0]);

            var userResult = await _userService.GetOneById(user1Id);

            _userRepoMock.Verify(repo => repo.GetOneById(user1Id), Times.Once());

            Assert.NotNull(userResult);
            Assert.IsType<UserReadDto>(userResult);
            Assert.Equal(users[0].FirstName, userResult.FirstName);
            Assert.Equal(users[0].LastName, userResult.LastName);
            Assert.Equal(users[0].Email, userResult.Email);
        }

        [Fact]
        public async Task GetOneById_With_WrongId_ThrowException()
        {
            Guid user1Id = Guid.NewGuid();
            _userRepoMock.Setup(repo => repo.GetOneById(user1Id)).ReturnsAsync((User)null);

            await Assert.ThrowsAsync<ErrorHandlerService>(async () => await _userService.GetOneById(user1Id));

            _userRepoMock.Verify(repo => repo.GetOneById(user1Id), Times.Once());
        }


    }
}