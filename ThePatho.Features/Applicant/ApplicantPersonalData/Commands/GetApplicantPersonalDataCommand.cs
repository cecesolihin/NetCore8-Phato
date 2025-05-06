using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataCommand :IRequest<ApiResponse<ApplicantPersonalDataItemDto>>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
        [JsonPropertyName("filter_NationalId")]
        public string? FilterNationalId { get; set; }
        [JsonPropertyName("filter_ReligionId")]
        public string? FilterReligionId { get; set; }
        [JsonPropertyName("filter_MaritalStatus")]
        public string? FilterMaritalStatus { get; set; }
        
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
