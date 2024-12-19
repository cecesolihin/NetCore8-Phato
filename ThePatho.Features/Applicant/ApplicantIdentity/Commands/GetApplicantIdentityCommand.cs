using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantIdentity.DTO;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class GetApplicantIdentityCommand :IRequest<ApplicantIdentityItemDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
        [JsonPropertyName("filter_Address")]
        public string? FilterAddress { get; set; }
        [JsonPropertyName("filter_City")]
        public string? FilterCity { get; set; }
        [JsonPropertyName("filter_Province")]
        public string? FilterProvince { get; set; }
        [JsonPropertyName("filter_Country")]
        public string? FilterCountry { get; set; }
        
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
