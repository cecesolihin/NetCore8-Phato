using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class DeleteApplicantDocumentCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }
        [JsonPropertyName("document_type_code")]
        public string DocumentTypeCode { get; set; }
    }
}
