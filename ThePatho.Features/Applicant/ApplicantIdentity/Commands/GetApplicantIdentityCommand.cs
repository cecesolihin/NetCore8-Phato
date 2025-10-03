using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
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
