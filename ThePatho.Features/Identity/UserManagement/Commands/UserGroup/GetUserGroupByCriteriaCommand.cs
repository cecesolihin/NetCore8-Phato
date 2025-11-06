using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.UserGroup
{
    public class GetUserGroupByCriteriaCommand : IRequest<ApiResponse<UserGroupItemDto>>
    {
        [JsonPropertyName("filter_User")]
        public string? FilterUser { get; set; }

        [JsonPropertyName("filter_Group")]
        public string? FilterGroup { get; set; }
        [JsonPropertyName("filter_DesGroup")]
        public string? FilterDesGroup { get; set; }
    }
}
