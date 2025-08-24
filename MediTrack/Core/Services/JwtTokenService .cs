using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediTrack.Core.Interfaces;
using MediTrack.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MediTrack.Core.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _config;
        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJWT(IEnumerable<Claim> claims)
        {
            var secretKey = _config["JWTSettings:SecretKey"];
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);

            var secuirtyKey = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(secuirtyKey, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds,
                Issuer = _config["JWTSettings:Issuer"],
                Audience = _config["JWTSettings:Audience"]
            };

            var securityTokenHandler = new JwtSecurityTokenHandler();
            var token = securityTokenHandler.WriteToken(new JwtSecurityTokenHandler().CreateToken(tokenDescriptor));

            return token;
        }

    }
}
