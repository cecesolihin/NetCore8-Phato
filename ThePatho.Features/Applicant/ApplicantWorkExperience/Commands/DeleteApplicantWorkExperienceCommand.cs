using MediatR;
namespace ThePatho.Features.Applicant.ApplicantWorkExperience.Commands
{
    public class DeleteApplicantWorkExperienceCommand : IRequest<bool>
    {
        public int AppWorkExpId { get; set; }
    }
}
