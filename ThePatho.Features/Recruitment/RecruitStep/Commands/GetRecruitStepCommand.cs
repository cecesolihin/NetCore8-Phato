using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Commands
{
    public class GetRecruitStepCommand :IRequest<ApiResponse<RecruitStepItemDto>>
    {
        [JsonPropertyName("filter_StepCode")]
        public string? FilterStepCode { get; set; }

        [JsonPropertyName("filter_StepName")]
        public string? FilterStepName { get; set; }

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
