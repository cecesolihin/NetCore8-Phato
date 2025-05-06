using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityCommand :IRequest<ApiResponse<ApplicantIdentityItemDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
        [JsonPropertyName("filter_IdentityCode")]
        public string? FilterIdentityCode { get; set; }
        [JsonPropertyName("filter_IdentityNo")]
        public string? FilterIdentityNo { get; set; }
        
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
