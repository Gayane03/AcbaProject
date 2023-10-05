using Microsoft.IdentityModel.Tokens;

namespace AcbaProject.Validations
{
    public interface IJwtService
    {
        public string GenerateToken(string username, string role);
        public TokenValidationParameters tokenValidationParameters();
    }
}