using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class DeleteCostCenterCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("costCenterCode")]
        public string CostCenterCode { get; set; } = null!;
    }
}
