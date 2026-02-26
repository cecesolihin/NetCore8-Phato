using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.DTO;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class GetCostCenterByCriteriaCommand : IRequest<ApiResponse<CostCenterItemDto>>
    {
        [JsonPropertyName("costCenterCode")]
        public string? CostCenterCode { get; set; }

        [JsonPropertyName("costCenterName")]
        public string? CostCenterName { get; set; }

        [JsonPropertyName("costCenterType")]
        public string? CostCenterType { get; set; }

    }
}
