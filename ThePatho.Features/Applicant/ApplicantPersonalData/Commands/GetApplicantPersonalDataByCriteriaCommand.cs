using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataByCriteriaCommand :IRequest<ApiResponse<ApplicantPersonalDataDto>> 
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
