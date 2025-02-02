using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class GetApplicantCommand :IRequest<NewApiResponse<ApplicantItemDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
        [JsonPropertyName("filter_Fullname")]
        public string? FilterFullname { get; set; }
        [JsonPropertyName("filter_Gender")]
        public string? FilterGender { get; set; }

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
