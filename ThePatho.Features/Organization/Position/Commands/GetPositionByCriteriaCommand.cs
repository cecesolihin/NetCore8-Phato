using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Position.DTO;

namespace ThePatho.Features.Organization.Position.Commands
{
    public class GetPositionByCriteriaCommand :IRequest<ApiResponse<PositionItemDto>>
    {
        [JsonPropertyName("orgStructureId")]
        public string? OrgStructureId { get; set; }
        [JsonPropertyName("jobLevelCode")]
        public string? JobLevelCode { get; set; }
    }
}
