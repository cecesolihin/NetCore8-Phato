using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class GetOrgLevelByCriteriaCommand :IRequest<ApiResponse<OrgLevelDto>>
    {
        [JsonPropertyName("filter_OrgLevelCode")]
        public string? OrgLevelCode { get; set; }
    }
}
