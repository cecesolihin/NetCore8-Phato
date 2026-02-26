using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class SubmitCostCenterCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("costCenterCode")]
        public string CostCenterCode { get; set; } = null!;

        [JsonPropertyName("costCenterName")]
        public string CostCenterName { get; set; } = null!;

        [JsonPropertyName("sortOrder")]
        public byte SortOrder { get; set; }

        [JsonPropertyName("costCenterType")]
        public string CostCenterType { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
