using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands
{
    public class GetUserGroupByCriteriaCommand : IRequest<UserGroupItemDto>
    {
        [JsonPropertyName("filter_Group")]
        public string? FilterGroup { get; set; }
        [JsonPropertyName("filter_User")]
        public string? FilterUser { get; set; }
    }
}
