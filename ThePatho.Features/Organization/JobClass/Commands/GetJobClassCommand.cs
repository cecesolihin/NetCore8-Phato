using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.JobClass.DTO;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class GetJobClassCommand : IRequest<ApiResponse<JobClassItemDto>>
    {
        [JsonPropertyName("jobClassCode")]
        public string? JobClassCode { get; set; }

        [JsonPropertyName("jobClassName")]
        public string? JobClassName { get; set; }

        [JsonPropertyName("gradeCode")]
        public string? GradeCode { get; set; }

        [JsonPropertyName("rankCode")]
        public string? RankCode { get; set; }

        [JsonPropertyName("sortBy")]
        [DefaultValue("InsertedDate")]
        public string? SortBy { get; set; } = "InsertedDate";

        [JsonPropertyName("orderBy")]
        [DefaultValue("DESC")]
        public string? OrderBy { get; set; } = "DESC";

        [JsonPropertyName("pageNumber")]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [JsonPropertyName("pageSize")]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}
