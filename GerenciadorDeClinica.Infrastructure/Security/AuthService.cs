using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GerenciadorDeClinica.Infrastructure.Security
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeHash(string password)
        {
            using (var hash = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);

                var hashedBytes = hash.ComputeHash(passwordBytes);

                var builder = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++ )
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string GenerateToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                
                new Claim("username", email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(issuer, audience, claims, null, DateTime.UtcNow.AddMinutes(10), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
