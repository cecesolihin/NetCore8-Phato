using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.EduMajor.Commands
{
    public class SubmitEduMajorCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("major_code")]
        public string? MajorCode { get; set; }

        [JsonPropertyName("major_name")]
        public string? MajorName { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}

