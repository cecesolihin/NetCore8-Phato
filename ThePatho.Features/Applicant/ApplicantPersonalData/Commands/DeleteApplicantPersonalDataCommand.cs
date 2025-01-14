using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Commands
{
    public class DeleteApplicantPersonalDataCommand : IRequest<bool>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; } 
    }
}
