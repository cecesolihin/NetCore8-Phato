using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepGroupDetailCommand : IRequest<ApiResponse<RecruitStepGroupDetailItemDto>>
    {
        [JsonPropertyName("filter_StepCode")]
        public string? FilterStepCode { get; set; }
        [JsonPropertyName("filter_StepGroupCode")]
        public string? FilterStepGroupCode { get; set; }
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
