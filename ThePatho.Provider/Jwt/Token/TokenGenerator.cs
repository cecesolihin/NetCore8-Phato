using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ThePatho.Provider.DateTimeProvider;

namespace ThePatho.Provider.Jwt.Token
{
    public sealed class TokenGenerator(JwtConfiguration jwtConfiguration, IDateTimeService dateTimeService, ILogger<TokenGenerator> logger)
    : ITokenGenerator
    {
        private string GenerateToken(byte[] key, string issuer, string audience, double expires,
            IEnumerable<Claim>? claims = default)
        {
            var secret = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            var timestamp = dateTimeService.ServerDateTimeNow;

            return new JwtSecurityTokenHandler().WriteToken(
             new JwtSecurityToken(
                 issuer,
                 audience,
                 claims,
                 timestamp,
                 timestamp.AddMinutes(expires),
                 credentials
             )
         );
        }

        public string GenerateToken(IEnumerable<Claim>? claims = default)
        {
            return GenerateToken(
                jwtConfiguration.AccessTokenSecret,
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                jwtConfiguration.AccessTokenExpiration,
                claims
            );
        }

        public string GenerateRefreshToken()
        {
            return GenerateToken(
                jwtConfiguration.RefreshTokenSecret,
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                jwtConfiguration.RefreshTokenExpiration
            );
        }

        public bool ValidateRefreshToken(string? refreshToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(jwtConfiguration.RefreshTokenSecret),
                ValidateLifetime = true,
                ValidIssuer = jwtConfiguration.Issuer,
                ValidAudience = jwtConfiguration.Audience,

                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.FromMinutes(1)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out _);
                return true;
            }
            catch (System.Exception e)
            {
                logger.LogError(e, e.Message);
                return false;
            }
        }
    }
}
