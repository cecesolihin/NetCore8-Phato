using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class SubmitJobClassCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("jobClassCode")]
        public string JobClassCode { get; set; } = null!;

        [JsonPropertyName("jobClassName")]
        public string JobClassName { get; set; } = null!;

        [JsonPropertyName("gradeCode")]
        public string GradeCode { get; set; } = null!;

        [JsonPropertyName("rankCode")]
        public string RankCode { get; set; } = null!;

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("isActive")]
        public bool? IsActive { get; set; }
        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
