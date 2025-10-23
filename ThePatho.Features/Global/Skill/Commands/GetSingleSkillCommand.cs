using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.DTO;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class GetSingleSkillCommand : IRequest<ApiResponse<SkillDto>>
    {
        [JsonPropertyName("filter_SkillCode")]
        public string FilterSkillCode { get; set; }
    }
}
