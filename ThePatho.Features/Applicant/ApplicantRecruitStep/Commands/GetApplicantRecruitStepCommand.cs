using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepCommand :IRequest<ApiResponse<ApplicantRecruitStepItemDto>>
    {
        [JsonPropertyName("filter_RecaApplicationId")]
        public string? FilterRecaApplicationId { get; set; }

        [JsonPropertyName("filter_RecruitStepCode")]
        public string? FilterRecruitStepCode { get; set; }

        [JsonPropertyName("filter_Status")]
        public string? FilterStatus { get; set; }

        [JsonPropertyName("filter_Province")]
        public string? FilterProvince { get; set; }

        [JsonPropertyName("filter_Country")]
        public string? FilterCountry { get; set; }
        
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
