using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{
    public class GetRecruitmentReqStepCommand :IRequest<ApiResponse<RecruitmentReqStepItemDto>>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }

        [JsonPropertyName("filter_StepCode")]
        public string? FilterStepCode { get; set; }

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
