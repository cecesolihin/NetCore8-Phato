using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Commands
{
    public class GetRecruitmentRequestCommand :IRequest<RecruitmentRequestItemDto>
    {
        [JsonPropertyName("filter_RequestNo")]
        public string? FilterRequestNo { get; set; }
        [JsonPropertyName("filter_RequestDate")]
        public string? FilterRequestDate { get; set; }
        [JsonPropertyName("filter_ApprovalStatus")]
        public string? FilterApprovalStatus { get; set; }

        [JsonPropertyName("filter_ApprovedDate")]
        public string? FilterApprovedDate { get; set; }

        [JsonPropertyName("filter_RequestType")]
        public string? FilterRequestType { get; set; }

        [JsonPropertyName("filter_MppPeriodCode")]
        public string? FilterMppPeriodCode { get; set; }

        [JsonPropertyName("filter_MppNo")]
        public string? FilterMppNo { get; set; }

        [JsonPropertyName("filter_OrganizationId")]
        public string? FilterOrganizationId { get; set; }

        [JsonPropertyName("filter_PositionCode")]
        public string? FilterPositionCode { get; set; }

        [JsonPropertyName("filter_JabatanId")]
        public string? FilterJabatanId { get; set; }

        [JsonPropertyName("filter_JobClassCode")]
        public string? FilterJobClassCode { get; set; }

        [JsonPropertyName("filter_VacancyName")]
        public string? FilterVacancyName { get; set; }
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
