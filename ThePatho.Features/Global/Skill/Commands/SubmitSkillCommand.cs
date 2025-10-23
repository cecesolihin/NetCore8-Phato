using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Skill.Commands
{
    public class SubmitSkillCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("skill_code")]
        public string SkillCode { get; set; } = null!;

        [JsonPropertyName("skill_name")]
        public string SkillName { get; set; } = null!;

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
