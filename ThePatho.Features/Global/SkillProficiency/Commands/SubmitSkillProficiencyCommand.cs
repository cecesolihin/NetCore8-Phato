using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.SkillProficiency.Commands
{
    public class SubmitSkillProficiencyCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("profiency_code")]
        public string ProfiencyCode { get; set; } = null!;

        [JsonPropertyName("profiency_name")]
        public string ProfiencyName { get; set; } = null!;

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
