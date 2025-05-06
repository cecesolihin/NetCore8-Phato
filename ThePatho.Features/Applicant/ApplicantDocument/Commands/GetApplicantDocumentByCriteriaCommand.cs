using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Features.Applicant.ApplicantDocument.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantDocument.Commands
{
    public class GetApplicantDocumentByCriteriaCommand :IRequest<ApiResponse<ApplicantDocumentDto>> 
    {
        [JsonPropertyName("filter_ApplicantNo")]
        public string? FilterApplicantNo { get; set; }
    }
}
