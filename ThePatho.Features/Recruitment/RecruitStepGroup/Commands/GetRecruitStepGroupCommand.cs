using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Commands
{
    public class GetRecruitStepGroupCommand : IRequest<ApiResponse<RecruitStepGroupItemDto>>
    {
        [JsonPropertyName("filter_StepGroupCode")]
        public string? FilterStepGroupCode { get; set; }
        [JsonPropertyName("filter_StepGroupName")]
        public string? FilterStepGroupName { get; set; }
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
