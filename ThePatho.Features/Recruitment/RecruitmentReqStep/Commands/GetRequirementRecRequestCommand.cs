using MediatR;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Commands
{
    public class GetRecruitmentReqStepCommand :IRequest<RecruitmentReqStepItemDto>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }
        [JsonPropertyName("filter_StepCode")]
        public string? FilterStepCode { get; set; }
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
