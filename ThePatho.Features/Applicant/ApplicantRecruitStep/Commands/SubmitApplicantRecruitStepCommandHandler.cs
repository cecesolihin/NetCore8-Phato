using MediatR;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class SubmitApplicantRecruitStepCommandHandler : IRequestHandler<SubmitApplicantRecruitStepCommand, string>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;

        public SubmitApplicantRecruitStepCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService = _applicantRecruitStepService;
        }

        public async Task<string> Handle(SubmitApplicantRecruitStepCommand request, CancellationToken cancellationToken)
        {
            await applicantRecruitStepService.SubmitApplicantRecruitStep(request);
            if (request.Action == "ADD")
            {
                return "Applicant Recruit Step successfully added.";
            }
            else if (request.Action == "EDIT")
            {
                return "Applicant Recruit Step successfully updated.";
            }

            throw new ArgumentException("Invalid action specified. Use 'ADD' or 'EDIT'.");
        }
    }
}
