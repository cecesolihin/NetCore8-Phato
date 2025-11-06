using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.UserRole
{
    public class GetUserRoleByCriteriaCommand : IRequest<ApiResponse<UserRoleItemDto>>
    {
        [JsonPropertyName("filter_User")]
        public string? FilterUser { get; set; }

        [JsonPropertyName("filter_Role")]
        public string? FilterRole { get; set; }
        [JsonPropertyName("filter_DesRole")]
        public string? FilterDesRole { get; set; }
    }
}
