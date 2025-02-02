using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.ConfigurationExtensions.Jwt;
using ThePatho.Features.Identity.Authentication.DTO;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class RegisterCommand : IRequest<NewApiResponse<JwtResult>>
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
