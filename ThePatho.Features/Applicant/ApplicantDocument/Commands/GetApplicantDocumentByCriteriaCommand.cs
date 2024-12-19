using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class GetApplicantDocumentByCriteriaCommand :IRequest<ApplicantDocumentDto>
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
