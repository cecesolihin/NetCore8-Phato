using MediatR;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class SubmitApplicantRecruitStepCommandHandler : IRequestHandler<SubmitApplicantRecruitStepCommand, ApiResponse>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;

        public SubmitApplicantRecruitStepCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService = _applicantRecruitStepService;
        }

        public async Task<ApiResponse> Handle(SubmitApplicantRecruitStepCommand request, CancellationToken cancellationToken)
        {
            return await applicantRecruitStepService.SubmitApplicantRecruitStep(request);
            
        }
    }
}
