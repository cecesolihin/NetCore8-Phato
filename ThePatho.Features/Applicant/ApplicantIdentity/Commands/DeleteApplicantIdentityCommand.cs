using MediatR;

namespace ThePatho.Features.Applicant.ApplicantIdentity.Commands
{
    public class DeleteApplicantIdentityCommand : IRequest<bool>
    {
        public string ApplicantNo { get; set; }
        public string IdentityCode { get; set; }
    }
}
