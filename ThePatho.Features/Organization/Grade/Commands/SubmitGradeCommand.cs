using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class SubmitGradeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("grade_code")]
        public string GradeCode { get; set; } = null!;

        [JsonPropertyName("grade_name")]
        public string GradeName { get; set; } = null!;

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("order")]
        public byte SortOrder { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
