using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class GetGradeCommand : IRequest<ApiResponse<GradeItemDto>>
    {
        [JsonPropertyName("filter_grade_code")]
        public string FilterGradeCode { get; set; } = null!;

        [JsonPropertyName("filter_grade_name")]
        public string FilterGradeName { get; set; } = null!;

        [JsonPropertyName("filter_status")]
        public string? FilterStatus { get; set; }

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
