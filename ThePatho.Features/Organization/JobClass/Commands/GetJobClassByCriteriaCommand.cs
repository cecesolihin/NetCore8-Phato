using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.DTO;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class GetJobClassByCriteriaCommand : IRequest<ApiResponse<JobClassItemDto>>
    {
        [JsonPropertyName("jobClassCode")]
        public string? JobClassCode { get; set; }

        [JsonPropertyName("jobClassName")]
        public string? JobClassName { get; set; }

        [JsonPropertyName("gradeCode")]
        public string? GradeCode { get; set; }

        [JsonPropertyName("rankCode")]
        public string? RankCode { get; set; }

    }
}
