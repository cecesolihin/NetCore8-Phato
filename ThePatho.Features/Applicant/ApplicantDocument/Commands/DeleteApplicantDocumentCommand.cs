using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class DeleteApplicantDocumentCommand : IRequest<bool>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }
        [JsonPropertyName("document_type_code")]
        public string DocumentTypeCode { get; set; }
    }
}
