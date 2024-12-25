using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepCommand :IRequest<ApplicantRecruitStepItemDto>
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
        public string? SortBy { get; set; } = "InsertedDate";
        [JsonPropertyName("orderBy")]
        public string? OrderBy { get; set; } = "DESC";
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 0;
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10; 
    }
}
