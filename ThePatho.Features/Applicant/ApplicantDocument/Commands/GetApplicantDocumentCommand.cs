using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class GetApplicantDocumentCommand :IRequest<ApplicantDocumentItemDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
        [JsonPropertyName("filter_DocumetnType")]
        public string? FilterDocumetnType { get; set; }

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
