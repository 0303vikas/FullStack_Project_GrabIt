using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GrabIt.Core.src.Entities;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Service.Dtos;
using GrabIt.Service.ErrorHandler;
using GrabIt.Service.src.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GrabIt.Service.src.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _config;

        public AuthService(IUserRepo userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<string> Authenticate(UserLoginDto credentials)
        {
            var foundUser = await _userRepo.FindOneByEmail(credentials.Email) ?? throw ErrorHandlerService.ExceptionInvalidData("Email not valid.");
            var checkPassword = HashingService.VerifyPassword(credentials.Password, foundUser.Salt, foundUser.Password);
            if (!checkPassword) throw ErrorHandlerService.ExceptionInvalidData("Password not valid.");
            return await CreateToken(foundUser);
        }

        public async Task<string> CreateToken(User user)
        {
            string secretKey = _config["Jwt:Key"] ?? "backeupSecretKey";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Uri, user.ImageURL)
            };

            string secretIssuer = _config["Jwt:Issuer"] ?? "backupSecretIssuer";

            var token = new JwtSecurityToken(
                issuer: secretIssuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> AbstractClaims(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            var claims = tokenS.Claims ?? throw ErrorHandlerService.ExceptionInvalidData("Token not valid.");
            var user = new User
            {
                Email = claims.First(claim => claim.Type == ClaimTypes.Email).Value,
                Role = (UserRole)Enum.Parse(typeof(UserRole), claims.First(claim => claim.Type == ClaimTypes.Role).Value),
                FirstName = claims.First(claim => claim.Type == ClaimTypes.Name).Value,
                Id = Guid.Parse(claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value),
                LastName = claims.First(claim => claim.Type == ClaimTypes.Surname).Value,
                ImageURL = claims.First(claim => claim.Type == ClaimTypes.Uri).Value
            };
            return user;
        }
    }
}