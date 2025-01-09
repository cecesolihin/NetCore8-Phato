using MediatR;
namespace ThePatho.Features.Applicant.ApplicantOnlineTestAnswer.Commands
{
    public class DeleteApplicantOnlineTestAnswerCommand : IRequest<bool>
    {
        public int AppAnswerId { get; set; }
    }
}
