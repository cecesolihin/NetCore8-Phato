using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class ChangePasswordCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("current_password")]
        public string CurrentPassword { get; set; } = string.Empty;

        [JsonPropertyName("new_password")]
        public string NewPassword { get; set; } = string.Empty;
    }
}