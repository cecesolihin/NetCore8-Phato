using MediatR;
using System.Text.Json.Serialization;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class DeleteApplicantIdentityCommand : IRequest<bool>
    {
        [JsonPropertyName("applicant_no")]
        public string ApplicantNo { get; set; }

        [JsonPropertyName("identity_code")]
        public string IdentityCode { get; set; }
    }
}
