using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.Jwt;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class RefreshTokenCommand : IRequest<ApiResponse<JwtResult>>
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;
        
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; } = string.Empty;
    }
}