using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.DTO;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class GetSkillProficiencyByCriteriaCommand : IRequest<ApiResponse<SkillProficiencyItemDto>>
    {
        [JsonPropertyName("profiencyName")]
        public string? ProfiencyName { get; set; }

        [JsonPropertyName("profiencyCode")]
        public string? ProfiencyCode { get; set; }

    }
}
