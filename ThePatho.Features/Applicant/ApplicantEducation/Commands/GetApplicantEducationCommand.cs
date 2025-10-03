using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationCommand :IRequest<ApiResponse<ApplicantEducationItemDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }

        [JsonPropertyName("filter_EdulLevel")]
        public string? FilterEdulLevel { get; set; }

        [JsonPropertyName("filter_Major")]
        public string? FilterMajor { get; set; }

        [JsonPropertyName("filter_Faculty")]
        public string? FilterFaculty { get; set; }

        [JsonPropertyName("filter_Institution")]
        public string? FilterInstitution { get; set; }
        
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
