using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using ThePatho.Provider.DateTimeProvider;

namespace ThePatho.Provider.Jwt.Token
{
    public sealed class TokenGenerator(JwtConfiguration jwtConfiguration, IDateTimeService dateTimeService, ILogger<TokenGenerator> logger)
    : ITokenGenerator
    {
        private string GenerateToken(string key, string issuer, string audience, int expiresMinutes,
            IEnumerable<Claim>? claims = default)
        {
            var secretKeyBytes = Convert.FromBase64String(key);
            var secret = new SymmetricSecurityKey(secretKeyBytes);
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            var timestamp = dateTimeService.ServerDateTimeNow;

            return new JwtSecurityTokenHandler().WriteToken(
             new JwtSecurityToken(
                 issuer,
                 audience,
                 claims,
                 timestamp,
                 timestamp.AddMinutes(expiresMinutes),
                 credentials
             )
         );
        }

        public string GenerateToken(IEnumerable<Claim>? claims = default)
        {
            return GenerateToken(
                jwtConfiguration.Key,
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                jwtConfiguration.ExpiryMinutes,
                claims
            );
        }

        public string GenerateRefreshToken()
        {
            return GenerateToken(
                jwtConfiguration.Key,
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                jwtConfiguration.ExpiryMinutes * 24 // Refresh token berlaku 24 jam
            );
        }

        public bool ValidateRefreshToken(string? refreshToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtConfiguration.Key)),
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
