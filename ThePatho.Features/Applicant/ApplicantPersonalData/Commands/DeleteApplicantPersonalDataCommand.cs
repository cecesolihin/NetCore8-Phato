using MediatR;
using System.Text.Json.Serialization;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class DeleteApplicantPersonalDataCommand : IRequest<ApiResponse>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; } 
    }
}
