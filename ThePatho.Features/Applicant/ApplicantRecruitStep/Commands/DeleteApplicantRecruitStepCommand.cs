using MediatR;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class DeleteApplicantRecruitStepCommand : IRequest<bool>
    {
        public int RecApplicationId { get; set; }
        public string RecruitStepCode { get; set; }
    }
}
