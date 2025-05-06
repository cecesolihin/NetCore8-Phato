using MediatR;
using ThePatho.Features.Applicant.ApplicantRecruitStep.DTO;
using ThePatho.Features.Applicant.ApplicantRecruitStep.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantRecruitStep.Commands
{
    public class GetApplicantRecruitStepCommandHandler : IRequestHandler<GetApplicantRecruitStepCommand, ApiResponse<ApplicantRecruitStepItemDto>>
    {
        private readonly IApplicantRecruitStepService applicantRecruitStepService;
        public GetApplicantRecruitStepCommandHandler(IApplicantRecruitStepService _applicantRecruitStepService)
        {
            applicantRecruitStepService =_applicantRecruitStepService;
        }
        public async Task<ApiResponse<ApplicantRecruitStepItemDto>> Handle(GetApplicantRecruitStepCommand request, CancellationToken cancellationToken)
        {
            return await applicantRecruitStepService.GetApplicantRecruitStep(request);

        }
    }
}
