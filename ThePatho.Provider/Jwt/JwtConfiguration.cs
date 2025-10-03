
namespace ThePatho.Provider.Jwt
{
    public sealed class JwtConfiguration
    {
        public string Key { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public int ExpiryMinutes { get; init; } = 60;
    }
}
