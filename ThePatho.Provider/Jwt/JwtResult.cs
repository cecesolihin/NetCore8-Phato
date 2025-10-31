
namespace ThePatho.Provider.Jwt
{
    public record JwtResult(string Token, string RefreshToken, string ExpiresAt);
}
