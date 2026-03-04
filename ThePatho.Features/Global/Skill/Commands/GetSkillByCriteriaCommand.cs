using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.DTO;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class GetSkillByCriteriaCommand : IRequest<ApiResponse<SkillItemDto>>
    {
        [JsonPropertyName("skillName")]
        public string? SkillName { get; set; }

        [JsonPropertyName("skillCode")]
        public string? SkillCode { get; set; }

    }
}
