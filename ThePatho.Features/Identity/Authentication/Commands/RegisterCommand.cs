using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.Jwt;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class RegisterCommand : IRequest<ApiResponse<JwtResult>>
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("fullname")]
        public string? Fullname { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }
        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}
