using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.DTO;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class GetApplicantOnlineTestAnswerCommand :IRequest<ApplicantOnlineTestAnswerItemDto>
    {
        [JsonPropertyName("filter_AppAnswerId")]
        public string? FilterAppAnswerId { get; set; }
        [JsonPropertyName("filter_AppResultId")]
        public string? FilterAppResultId { get; set; }
         
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
