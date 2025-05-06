using MediatR;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepByCriteriaCommandHandler : IRequestHandler<GetApplicantRecruitStepByCriteriaCommand, ApiResponse<ApplicantRecruitStepDto>>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;
        public GetApplicantRecruitStepByCriteriaCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService = _applicantRecruitStepService;
        }
        public async Task<ApiResponse<ApplicantRecruitStepDto>> Handle(GetApplicantRecruitStepByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await applicantRecruitStepService.GetApplicantRecruitStepByCriteria(request);

        }
    }
}
