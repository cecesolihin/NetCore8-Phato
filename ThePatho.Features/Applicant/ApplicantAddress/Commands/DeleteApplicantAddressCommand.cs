using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantAddress.Commands
{
    public class DeleteApplicantAddressCommand : IRequest<bool>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; } 
    }
}
