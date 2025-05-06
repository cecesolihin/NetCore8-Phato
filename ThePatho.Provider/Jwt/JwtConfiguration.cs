
namespace ThePatho.Provider.Jwt
{
    public sealed class JwtConfiguration
    {
        public byte[] AccessTokenSecret { get; init; }
        public byte[] RefreshTokenSecret { get; init; }
        public double AccessTokenExpiration { get; init; }
        public double RefreshTokenExpiration { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
    }
}
