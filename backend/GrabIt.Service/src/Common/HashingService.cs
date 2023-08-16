using System.Security.Cryptography;
using System.Text;

namespace GrabIt.Service.src.Implementations
{
    public class HashingService
    {
        public static void HashPassword(string password, out byte[] salt, out string hashPassword)
        {
            var hash = new HMACSHA256();
            salt = hash.Key;
            hashPassword = Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public static bool VerifyPassword(string password, byte[] salt, string hashPassword)
        {
            var hash = new HMACSHA256(salt);
            return Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(password))) == hashPassword;
        }

    }
}