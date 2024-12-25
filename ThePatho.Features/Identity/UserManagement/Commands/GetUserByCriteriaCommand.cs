using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetUserByCriteriaCommand : IRequest<UserDto>
    {
        [JsonPropertyName("filter_UserId")]
        public string? FilterUserId { get; set; }
        [JsonPropertyName("filter_UserName")]
        public string? FilterUserName { get; set; }
    }
}
