using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class UserReadDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public List<Address> Addresses { get; set; }
        public Image ImageURL { get; set; }
    }


    public class UserCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Image ImageUrl { get; set; }
        public string Password { get; set; }

    }

    public class UserUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public List<Address> Addresses { get; set; }
        public Image ImageUrl { get; set; }
    }

    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

