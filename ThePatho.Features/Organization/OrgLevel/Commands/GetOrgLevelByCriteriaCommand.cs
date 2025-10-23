using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelByCriteriaCommand :IRequest<ApiResponse<OrgLevelItemDto>>
    {
        [JsonPropertyName("orgLevelCode")]
        public string? OrgLevelCode { get; set; }

        [JsonPropertyName("orgLevelName")]
        public string? OrgLevelName { get; set; }
    }
}
