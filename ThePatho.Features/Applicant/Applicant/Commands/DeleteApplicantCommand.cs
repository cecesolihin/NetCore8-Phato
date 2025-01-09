using MediatR;

namespace ThePatho.Features.Applicant.Applicant.Commands
{
    public class DeleteApplicantCommand : IRequest<bool>
    {
        public string ApplicantNo { get; set; } 
    }
}
