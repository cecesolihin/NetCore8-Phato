using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class GetOrgStructureByCriteriaCommand :IRequest<ApiResponse<OrgStructureDto>>
    {
        [JsonPropertyName("filter_OrgLevelCode")]
        public string OrgLevelCode { get; set; }
    }
}
