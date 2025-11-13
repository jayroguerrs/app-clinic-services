using DepilZone.Entidad.DTO;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DepilZone.Api.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(LoginDTO user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);            
            var tokenDes = new SecurityTokenDescriptor            
            {
                Subject = new ClaimsIdentity(
                    [
                              new Claim(JwtRegisteredClaimNames.Sub, user.Usuario),                              
                              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
                        ]
                    ),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(byteKey),
                    SecurityAlgorithms.HmacSha256Signature  
                )
            };
            var token = tokenHandler.CreateToken(tokenDes);

            return tokenHandler.WriteToken(token);
    
        }

    }
}
