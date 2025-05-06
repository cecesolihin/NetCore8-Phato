using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RequirementMaster.DTO;

namespace ThePatho.Features.Recruitment.RequirementMaster.Commands
{
    public class GetRequirementMasterCommand :IRequest<ApiResponse<RequirementMasterItemDto>>
    {
        [JsonPropertyName("filter_QuestionCode")]
        public string? FilterQuestionCode { get; set; }
        [JsonPropertyName("filter_QuestionName")]
        public string? FilterQuestionName { get; set; }
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
