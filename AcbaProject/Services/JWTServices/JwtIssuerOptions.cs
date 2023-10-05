using Microsoft.IdentityModel.Tokens;
public class JwtIssuerOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
    public SecurityKey SigningKey { get; set; }
    public SigningCredentials SigningCredentials { get; set; }
    public TimeSpan ValidFor { get; set; } = TimeSpan.FromHours(5);
    public DateTime IssuedAt => DateTime.UtcNow;
}