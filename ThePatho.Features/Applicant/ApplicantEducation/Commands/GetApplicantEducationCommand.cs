using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantEducation.DTO;

namespace ThePatho.Features.Applicant.ApplicantEducation.Commands
{
    public class GetApplicantEducationCommand :IRequest<ApplicantEducationItemDto>
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
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10; 
    }
}
