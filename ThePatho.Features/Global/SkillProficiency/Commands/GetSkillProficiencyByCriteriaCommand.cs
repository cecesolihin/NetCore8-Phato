using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.DTO;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class GetSkillProficiencyByCriteriaCommand : IRequest<ApiResponse<SkillProficiencyItemDto>>
    {
        [JsonPropertyName("filter_ProfiencyName")]
        public string? FilterProfiencyName { get; set; }

        [JsonPropertyName("filter_ProfiencyCode")]
        public string? FilterProfiencyCode { get; set; }

    }
}
