using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.EduLevel.Commands
{
    public class SubmitEduLevelCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("edu_level_code")]
        public string? EduLevelCode { get; set; }

        [JsonPropertyName("edu_level_name")]
        public string? EduLevelName { get; set; }
        [JsonPropertyName("sort")]
        public int Sort { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

