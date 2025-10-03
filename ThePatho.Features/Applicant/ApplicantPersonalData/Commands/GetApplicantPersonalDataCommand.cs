using MediatR;
using System.Text.Json.Serialization;
using System.ComponentModel;
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
