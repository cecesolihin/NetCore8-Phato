using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class GetApplicantDocumentByCriteriaCommand :IRequest<NewApiResponse<ApplicantDocumentDto>> 
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
