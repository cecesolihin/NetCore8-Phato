using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.DTO;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class GetSkillByCriteriaCommand : IRequest<ApiResponse<SkillItemDto>>
    {
        [JsonPropertyName("filter_SkillName")]
        public string? FilterSkillName { get; set; }

        [JsonPropertyName("filter_SkillCode")]
        public string? FilterSkillCode { get; set; }

    }
}
