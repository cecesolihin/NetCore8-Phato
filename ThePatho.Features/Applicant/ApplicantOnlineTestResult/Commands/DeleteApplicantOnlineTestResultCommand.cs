using MediatR;

namespace ThePatho.Features.Applicant.ApplicantOnlineTestResult.Commands
{
    public class DeleteApplicantOnlineTestResultCommand : IRequest<bool>
    {
        public int AppResultId { get; set; }
    }
}
