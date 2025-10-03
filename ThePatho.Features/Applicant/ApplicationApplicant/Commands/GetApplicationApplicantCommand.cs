using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Features.Applicant.ApplicationApplicant.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicationApplicant.Commands
{
    public class GetApplicationApplicantCommand :IRequest<ApiResponse<ApplicationApplicantItemDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; } 

        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }

        [JsonPropertyName("filter_Status")]
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
