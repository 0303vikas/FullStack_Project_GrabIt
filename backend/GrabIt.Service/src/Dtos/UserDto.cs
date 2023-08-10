using GrabIt.Core.src.Entities;

namespace GrabIt.Service.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public List<Address> Addresses { get; set; }
        public Image ImageURL { get; set; }
    }

    //public string Password { get; set; }

    public class CreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }


}

