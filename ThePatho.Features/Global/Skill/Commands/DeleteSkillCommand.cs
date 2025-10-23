using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class DeleteSkillCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("skill_code")]
        public string SkillCode { get; set; }
    }
}
