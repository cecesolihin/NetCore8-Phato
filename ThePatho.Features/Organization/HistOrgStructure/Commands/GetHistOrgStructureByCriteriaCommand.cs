using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.HistOrgStructure.DTO;

namespace ThePatho.Features.Organization.HistOrgStructure.Commands
{
    public class GetHistOrgStructureByCriteriaCommand : IRequest<ApiResponse<HistOrgStructureItemDto>>
    {
        [JsonPropertyName("orgStructureCode")]
        public string? OrgStructureCode { get; set; }

        [JsonPropertyName("orgStructureName")]
        public string? OrgStructureName { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("companyCode")]
        public string? CompanyCode { get; set; }

        [JsonPropertyName("costCenterCode")]
        public string? CostCenterCode { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }


    }
}
