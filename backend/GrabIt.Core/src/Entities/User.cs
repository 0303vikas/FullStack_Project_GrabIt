namespace GrabIt.Core.src.Entities
{
    public class User : BaseEntityWithDate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public List<Address> Addresses { get; set; }
        public Image ImageURL { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Customer
    }
}
