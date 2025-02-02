using MediatR;
using System;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class DeleteApplicantRecruitStepCommandHandler : IRequestHandler<DeleteApplicantRecruitStepCommand, ApiResponse>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;

        public DeleteApplicantRecruitStepCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService = _applicantRecruitStepService;
        }

        public async Task<ApiResponse> Handle(DeleteApplicantRecruitStepCommand request, CancellationToken cancellationToken)
        {
            return await applicantRecruitStepService.DeleteApplicantRecruitStep(request);
                
        }
    }
}
