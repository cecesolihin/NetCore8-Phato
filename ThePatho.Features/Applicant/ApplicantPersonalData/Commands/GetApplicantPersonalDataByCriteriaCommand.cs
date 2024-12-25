using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataByCriteriaCommand :IRequest<ApplicantPersonalDataDto> 
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
