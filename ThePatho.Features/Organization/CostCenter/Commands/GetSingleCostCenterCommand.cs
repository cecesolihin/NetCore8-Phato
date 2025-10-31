using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.DTO;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class GetSingleCostCenterCommand : IRequest<ApiResponse<CostCenterDto>>
    {
        [JsonPropertyName("cost_center_code")]
        public string CostCenterCode { get; set; } = null!;
    }
}
