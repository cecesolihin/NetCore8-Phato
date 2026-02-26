using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class SubmitGradeCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("gradeCode")]
        public string GradeCode { get; set; } = null!;

        [JsonPropertyName("gradeName")]
        public string GradeName { get; set; } = null!;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("sortOrder")]
        public byte SortOrder { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
