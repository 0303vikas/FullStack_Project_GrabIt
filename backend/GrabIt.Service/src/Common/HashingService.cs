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
            hashPassword = hash.ComputeHash(Encoding.UTF8.GetBytes(password)).ToString();
        }

        public static bool VerifyPassword(string password, byte[] salt, string hashPassword)
        {
            var hash = new HMACSHA256(salt);
            return hash.ComputeHash(Encoding.UTF8.GetBytes(password)).ToString() == hashPassword;
        }

    }
}