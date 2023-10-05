using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcbaProject.Validations
{
    public class JwtService : IJwtService
    {
        private readonly JwtIssuerOptions _options;
        public JwtService()
        {

        }

        public JwtService(IOptions<JwtIssuerOptions> options)
        {
            _options = options.Value;
            _options.Issuer = "AcbaProject";
            _options.Audience = "RestApi";
            _options.SigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("55ECA5D892291267C8DEFCCF91813"));
            _options.SigningCredentials = new SigningCredentials(_options.SigningKey, SecurityAlgorithms.HmacSha256);
        }

        public TokenValidationParameters tokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "AcbaProject",

                ValidateAudience = true,
                ValidAudience = "RestApi",

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("55ECA5D892291267C8DEFCCF91813")),

                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }

        public string GenerateToken(string username, string role)
        {
            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Iat, username),
                 new Claim(ClaimTypes.Role, role)
            };

            JwtSecurityToken token = new(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(5),
                signingCredentials: _options.SigningCredentials
            );

            JwtSecurityTokenHandler tokenHandler = new();
            return tokenHandler.WriteToken(token);
        }
    }
}
