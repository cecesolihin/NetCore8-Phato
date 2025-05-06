using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.UserManagement.DTO;

namespace ThePatho.Features.Identity.UserManagement.Commands.Group
{
    public class GetGroupByCriteriaCommand : IRequest<ApiResponse<GroupDto>>
    {
        [JsonPropertyName("filter_Group")]
        public string? FilterGroup { get; set; }
    }
}
