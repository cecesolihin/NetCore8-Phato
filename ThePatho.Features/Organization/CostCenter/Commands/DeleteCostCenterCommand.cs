using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class DeleteCostCenterCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("cost_center_code")]
        public string CostCenterCode { get; set; } = null!;
    }
}
