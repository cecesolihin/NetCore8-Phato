using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantWorkExperience.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class GetApplicantWorkExperienceCommand :IRequest<ApiResponse<ApplicantWorkExperienceItemDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
        [JsonPropertyName("filter_Company")]
        public string? FilterCompany { get; set; }
        [JsonPropertyName("filter_Organization")]
        public string? FilterOrganization { get; set; }
        [JsonPropertyName("filter_Joblevel")]
        public string? FilterJobLevel { get; set; }
        [JsonPropertyName("filter_JobDesc")]
        public string? FilterJobDesc { get; set; }
        
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
