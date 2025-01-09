using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class DeleteApplicantRecruitStepCommandHandler : IRequestHandler<DeleteApplicantRecruitStepCommand, bool>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;

        public DeleteApplicantRecruitStepCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService = _applicantRecruitStepService;
        }

        public async Task<bool> Handle(DeleteApplicantRecruitStepCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await applicantRecruitStepService.DeleteApplicantRecruitStep(request);
                return true;
            }
            catch
            {
                // Log the error here if needed
                return false;
            }
        }
    }
}
