using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class GetApplicantPersonalDataByCriteriaCommand :IRequest<NewApiResponse<ApplicantPersonalDataDto>> 
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
