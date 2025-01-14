using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class DeleteApplicantCommand : IRequest<bool>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; } 
    }
}
