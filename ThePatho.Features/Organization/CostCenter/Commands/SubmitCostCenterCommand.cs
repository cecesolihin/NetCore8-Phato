using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class SubmitCostCenterCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("cost_center_code")]
        public string CostCenterCode { get; set; } = null!;

        [JsonPropertyName("cost_center_name")]
        public string CostCenterName { get; set; } = null!;

        [JsonPropertyName("sort")]
        public byte Sort { get; set; }

        [JsonPropertyName("cost_center_type")]
        public string CostCenterType { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
