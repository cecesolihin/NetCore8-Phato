using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.DTO;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class GetCostCenterByCriteriaCommand : IRequest<ApiResponse<CostCenterItemDto>>
    {
        [JsonPropertyName("filter_CostCenterCode")]
        public string? FilterCostCenterCode { get; set; } = null!;

        [JsonPropertyName("filter_CostCenterName")]
        public string? FilterCostCenterName { get; set; } = null!;

        [JsonPropertyName("filter_CostCenterType")]
        public string? FilterCostCenterType { get; set; } = null!;

    }
}
