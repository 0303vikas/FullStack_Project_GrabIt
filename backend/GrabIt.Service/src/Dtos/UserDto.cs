using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string ImageURL { get; set; }

        public List<AddressReadDto> Addresses { get; set; }
        public List<OrderReadDto> Orders { get; set; }
    }


    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public string Password { get; set; }

    }

    public class UserUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
    }

    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserPasswordUpdateDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

